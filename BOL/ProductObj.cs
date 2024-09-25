using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BOL
{
    public class ProductObj
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }

    }

    //{ SAMPLE REQUEAST 
    //  "id": "60c72b2f5f1b2c6a4c8e1234",
    //  "name": "Product A",
    //  "category": "Electronics",
    //  "price": 99.99
    //}


}
