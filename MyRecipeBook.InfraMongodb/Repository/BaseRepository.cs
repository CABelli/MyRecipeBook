using MongoDB.Driver;
using MyRecipeBook.InfraMongodb.InterfaceContext;

namespace MyRecipeBook.InfraMongodb.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("Id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<TEntity> GetByName(string nameProduct)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("NameProduct", nameProduct));
            return data.SingleOrDefault();
        }

        public virtual async void Add(TEntity obj)
        {
            //  ESSA AQUI FUNCIONA SEM O CONTEXT
                 await DbSet.InsertOneAsync(obj);

            // Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public virtual async void UpdateObj(TEntity obj)
        {
            //Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", "647777af0f615394bc74891b"), obj));

            await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", "647777af0f615394bc74891b"), obj);
        }

        public virtual void RemoveObj(string id)
        {
            // Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id)));

            DbSet.DeleteMany(Builders<TEntity>.Filter.Eq("Id", id));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
