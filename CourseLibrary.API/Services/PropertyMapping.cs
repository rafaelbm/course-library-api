using System;
using System.Collections.Generic;

namespace CourseLibrary.API.Services;

public class PropertyMapping<TSource, TDestionation> : IPropertyMapping
{
    public Dictionary<string, PropertyMappingValue> MappingDictionary { get; }

    public PropertyMapping(Dictionary<string, PropertyMappingValue> mappingDictionary)
    {
        MappingDictionary = mappingDictionary ?? throw new ArgumentNullException(nameof(mappingDictionary));
    }
}