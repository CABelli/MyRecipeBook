using MongoDB.Driver;

namespace MyRecipeBook.InfraMongodb.InterfaceContext
{
    public interface IMongoContext
    {
        void AddCommand(Func<Task> func);

        Task<int> SaveChanges();

        IMongoCollection<T> GetCollection<T>(string name);

        void Dispose();
    }
}
