using MongoDB.Bson.Serialization.Attributes;

namespace ch_specification_demo_api.Models
{
    public class Beer : BaseModel
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("rating")]
        public double Rating { get; set; }
    }
}
