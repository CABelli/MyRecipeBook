using MyRecipeBook.InfraMongodb.InterfaceContext;
using MyRecipeBook.InfraMongodb.interfaceRepository;
using MyRecipeBook.InfraMongodb.Model;

namespace MyRecipeBook.InfraMongodb.Repository
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(IMongoContext context) : base(context)
        {
        }
    }
}
