using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyRecipeBook.InfraMongodb.Model
{
    public class Stock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string IdProduct { get; set; }

        public string DescriptionStock { get; set; }

        public int QuantityAvailable { get; set; }

        public int QuantityUsed { get; set; }
    }
}
