using System.Reflection.Metadata.Ecma335;

namespace uml_diagram.extensions;

public static class Ext
{
    public static object NewFrom(this object target, object source)
    {
        object instance = target;
        
        var srcProps = source.GetType().GetProperties();
        var targetProps = target.GetType().GetProperties();
        foreach (var propertyInfo in targetProps)
        {
            if (!propertyInfo.CanRead || !propertyInfo.CanWrite) continue;
            var sourceProp = srcProps.FirstOrDefault(p =>
                p.Name == propertyInfo.Name && p.PropertyType == propertyInfo.PropertyType);
            if (sourceProp is not null)
            {
                var value = sourceProp.GetValue(source);
                propertyInfo.SetValue(instance, value);
            }

        }

        return instance;
    }

    public static T? TryAs<T>(this object item)
    {
        if (item is T t)
        {
            return t;
        }

        throw new InvalidCastException();
    }
}