using MongoDB.Bson.Serialization;
using MyRecipeBook.InfraMongodb.Model;

namespace MyRecipeBook.InfraMongodb.Persistence
{
    public class StockMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Stock>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.IdProduct);
                map.MapMember(x => x.DescriptionStock);
                map.MapMember(x => x.QuantityAvailable);
                map.MapMember(x => x.QuantityUsed);
            });
        }
    }
}
