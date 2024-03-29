﻿using CourseLibrary.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace CourseLibrary.API.Helpers;

public static class IQueryableExtensions
{
    public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy,
        Dictionary<string, PropertyMappingValue> mappingDictionary)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (mappingDictionary is null)
        {
            throw new ArgumentNullException(nameof(mappingDictionary));
        }

        if (string.IsNullOrWhiteSpace(orderBy))
        {
            return source;
        }

        // the orderBy string is separated by "," so we split it.
        var orderByAfterSplit = orderBy.Split(',');

        foreach (var orderByClause in orderByAfterSplit.Reverse())
        {
            // trimi the orderBy clause, as it might contain leading
            // or trailling spaces. Can't trim the var in foreach,
            // so use another var.
            var trimmedOrderByClause = orderByClause.Trim();

            // if the sort option ends with " desc", we order
            // descending, otherwise ascending
            var orderDescending = trimmedOrderByClause.EndsWith(" desc");

            // remove " asc" or " desc" from the orderByClause so we 
            // get the property name to look for in the mapping dictionary
            var indexOfFirsSpace = trimmedOrderByClause.IndexOf(" ");
            var propertyName = indexOfFirsSpace == -1
                ? trimmedOrderByClause
                : trimmedOrderByClause.Remove(indexOfFirsSpace);

            // find the matching property
            if (!mappingDictionary.ContainsKey(propertyName))
            {
                throw new ArgumentException($"Key mapping for {propertyName} is missing");
            }

            // get the PropertyMappingValue
            var propertyMappingValue = mappingDictionary[propertyName];

            if(propertyMappingValue == null)
            {
                throw new ArgumentNullException("propertyMappingValue");
            }

            foreach (var destinationProperty in propertyMappingValue.DestinationProperties.Reverse())
            {
                // revert sort order if necessary
                if (propertyMappingValue.Rever)
                {
                    orderDescending = !orderDescending;
                }
                source = source.OrderBy(destinationProperty + (orderDescending
                    ? " descending"
                    : " ascending"));
            }
        }

        return source;
    }
}