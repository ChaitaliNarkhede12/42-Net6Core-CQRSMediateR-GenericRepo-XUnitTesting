using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Models;

namespace TCCS.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetById(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        Task RemoveById(int id);

        int SaveChanges();
        Task<int> SaveChangesAsync();


        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
