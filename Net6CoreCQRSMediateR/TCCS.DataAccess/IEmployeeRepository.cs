using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Models;

namespace TCCS.DataAccess
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<IEnumerable<Employee>> GetById(Expression<Func<Employee, bool>> predicate);
        Task<Employee> AddAsync(Employee entity);
        Employee Update(Employee entity);
        void Remove(Employee entity);
        Task RemoveById(int id);

        int SaveChanges();
        Task<int> SaveChangesAsync();


        Task<Employee> SingleOrDefaultAsync(Expression<Func<Employee, bool>> predicate);
        Task<Employee> FirstOrDefaultAsync(Expression<Func<Employee, bool>> predicate);

        void AddRange(IEnumerable<Employee> entities);
        Task AddRangeAsync(IEnumerable<Employee> entities);

        void UpdateRange(IEnumerable<Employee> entities);

        void RemoveRange(IEnumerable<Employee> entities);
    }
}
