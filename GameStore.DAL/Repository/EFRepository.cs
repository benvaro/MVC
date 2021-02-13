using GameStore.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DAL.Repository
{
    // Реалізувати нереалізовані методи в EFRepository
    public class EFRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _set;

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _set = _dbContext.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            _set.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _set.AsEnumerable();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
