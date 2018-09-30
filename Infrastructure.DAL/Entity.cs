using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.DAL
{
    /// <summary>
    /// Base class for any identifiable object.
    /// </summary>
    public class Entity : IEquatable<Entity>, IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        #region IEquatable
        public bool Equals(Entity other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
        #endregion
    }
}
