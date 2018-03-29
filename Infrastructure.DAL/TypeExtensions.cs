using System;
using System.Linq;

namespace Infrastructure.DAL
{
    public static class TypeExtensions
    {
        public static string GetCollectionName(this Type type)
        {
            return type
                .GetCustomAttributes(true)
                .OfType<CollectionNameAttribute>()
                .FirstOrDefault()?
                .CollectionName;
        }
    }
}
