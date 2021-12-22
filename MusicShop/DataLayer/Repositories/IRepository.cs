using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> Get(int id);
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> Insert(TEntity entity);
        public void Delete(TEntity entity);
        public Task Update(TEntity entity);
        public Task Save();
    }
}