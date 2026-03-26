using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExempleTestMongo.Entities
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; } 

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
