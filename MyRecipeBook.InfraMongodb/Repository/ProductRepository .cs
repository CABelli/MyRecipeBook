using MongoDB.Driver;
using MyRecipeBook.InfraMongodb.InterfaceContext;
using MyRecipeBook.InfraMongodb.interfaceRepository;
using MyRecipeBook.InfraMongodb.Model;

namespace MyRecipeBook.InfraMongodb.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoContext context) : base(context)
        {
        }
    }
}
