using MyRecipeBook.InfraSqlServer.Model;

namespace MyRecipeBook.InfraSqlServer.InterfaceRepository
{
    public interface IPriceProductClientRepository
    {
        Task<IEnumerable<PriceProductClient>> GetAllPrice(string titleRecipe);

        Task<List<PriceProductClient>> GetAllPrice02(string titleRecipe);

        Task AddPriceProductClient(PriceProductClient priceProductClient);
    }
}

