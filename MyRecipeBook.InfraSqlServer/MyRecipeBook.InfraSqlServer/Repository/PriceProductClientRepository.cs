using Microsoft.EntityFrameworkCore;
using MyRecipeBook.InfraSqlServer.InterfaceRepository;
using MyRecipeBook.InfraSqlServer.Model;

namespace MyRecipeBook.InfraSqlServer.Repository
{
    public class PriceProductClientRepository : IPriceProductClientRepository
    {
        public readonly DbContext _dbContext;
        public readonly DbSet<PriceProductClient> _dbSet;

        public PriceProductClientRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<PriceProductClient>();
        }

        public Task<List<PriceProductClient>> GetAllPrice()
        {
            return _dbSet.AsQueryable().ToListAsync<PriceProductClient>();
        }

        public async Task AddPriceProductClient(PriceProductClient priceProductClient)
        {
            _dbSet.Add(priceProductClient);

            var rows = await _dbContext.SaveChangesAsync();
            Console.WriteLine($"Deu certo - rows: {rows} !!!");

            //await _dbSet.
            //await _unitOfWork.CommitAsync();
        }
    }
}
