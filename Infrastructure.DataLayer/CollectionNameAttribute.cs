using System;

namespace Infrastructure.DataLayer
{
    /// <summary>
    /// Specifies the name of database collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CollectionNameAttribute : Attribute
    {
        public string CollectionName { get; }

        public CollectionNameAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
