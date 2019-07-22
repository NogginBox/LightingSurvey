using System;

namespace LightingSurvey.MvcSite.Extensions
{
    public static class TypeExtensions
    {
        public static object CreateGenricInstance(this Type tGeneric, Type tOf)
        {
            Type[] typeArgs = { tOf };
            var makeme = tGeneric.MakeGenericType(typeArgs);
            return Activator.CreateInstance(makeme);
        }
    }
}