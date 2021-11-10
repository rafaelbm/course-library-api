using System.Reflection;

namespace CourseLibrary.API.Services;

public class PropertyCheckerService : IPropertyCheckerService
{
    public bool TypeHasProperties<T>(string fields)
    {
        if (string.IsNullOrWhiteSpace(fields))
        {
            return true;
        }

        // the field are separated by ",", so we split it.
        var fieldsAfterSplit = fields.Split(',');

        // check if the requeusted fields exists on source
        foreach (var field in fieldsAfterSplit)
        {
            var propertyName = field.Trim();

            // use reflection to check if the property can be
            // found on T.
            var propertyInfo = typeof(T)
                .GetProperty(propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            // it can't be found, return false
            if (propertyInfo == null)
            {
                return false;
            }
        }

        return true;
    }
}