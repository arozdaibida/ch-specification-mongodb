using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ch_specification_demo_api.Models
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
