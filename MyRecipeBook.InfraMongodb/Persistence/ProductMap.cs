using MongoDB.Bson.Serialization;
using MyRecipeBook.InfraMongodb.Model;

namespace MyRecipeBook.InfraMongodb.Persistence
{
    public class ProductMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Product>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.NameProduct).SetIsRequired(true);
            });
        }
    }
}
