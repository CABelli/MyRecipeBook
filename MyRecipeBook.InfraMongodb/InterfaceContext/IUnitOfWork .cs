namespace MyRecipeBook.InfraMongodb.InterfaceContext
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
