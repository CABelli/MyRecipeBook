namespace MyRecipeBook.InfraMongodb.InterfaceContext
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        Task<TEntity> GetById(string id);

        Task<TEntity> GetByName(string nameProduct);

        Task<IEnumerable<TEntity>> GetAll();

        void UpdateObj(TEntity obj);

        void RemoveObj(string id);
    }
}
