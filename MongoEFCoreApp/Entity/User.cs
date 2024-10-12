using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoEFCoreApp.Entity
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("isActive")]
        public bool isActive { get; set; }

    }
}
