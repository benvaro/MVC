using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.DAL.Repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
    }
}
