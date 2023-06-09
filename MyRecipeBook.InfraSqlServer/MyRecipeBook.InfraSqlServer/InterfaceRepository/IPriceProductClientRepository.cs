using MyRecipeBook.InfraSqlServer.Model;

namespace MyRecipeBook.InfraSqlServer.InterfaceRepository
{
    public interface IPriceProductClientRepository
    {
        Task<List<PriceProductClient>> GetAllPrice();

        Task AddPriceProductClient(PriceProductClient priceProductClient);
    }
}

