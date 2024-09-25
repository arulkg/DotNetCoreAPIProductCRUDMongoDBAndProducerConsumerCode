using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace BOL
{
    public class TaskMessage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Payload { get; set; }
        public string? Status { get; set; }
        public DateTime? CreaedAt { get; set; } = DateTime.UtcNow;
    }
}
