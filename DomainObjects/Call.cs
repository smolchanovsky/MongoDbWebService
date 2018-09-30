using System;
using DomainObjects.Enums;
using Infrastructure.DAL;
using MongoDB.Bson.Serialization.Attributes;

namespace DomainObjects
{
    /// <summary>
    /// Domain model for Call entity.
    /// </summary>
    [CollectionName("calls")]
    public class Call : Entity
    {
        [BsonElement("duration")]
        public TimeSpan Duration { get; set; }
        [BsonElement("status")]
        public CallStatusType Status { get; set; }
        [BsonElement("startOn")]
        public DateTime StartOn { get; set; }
        [BsonElement("connectionOn")]
        public DateTime ConnectionOn { get; set; }
        [BsonElement("terminateOn")]
        public DateTime TerminateOn { get; set; }
    }
}
