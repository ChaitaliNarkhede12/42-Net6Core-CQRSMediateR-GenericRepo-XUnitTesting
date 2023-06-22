using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Models;

namespace TCCS.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IRepository<Employee> _repo;

        public EmployeeRepository(IRepository<Employee> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<IEnumerable<Employee>> GetById(Expression<Func<Employee, bool>> predicate)
        {
            return await _repo.GetById(predicate);
        }




        public async Task<Employee> AddAsync(Employee entity)
        {
            return await _repo.AddAsync(entity);
        }

        public Employee Update(Employee entity)
        {
            return _repo.Update(entity);
        }


        public void Remove(Employee entity)
        {
            _repo.Remove(entity);
        }

        public async Task RemoveById(int id)
        {
            await _repo.RemoveById(id);
        }



        public int SaveChanges()
        {
            return _repo.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _repo.SaveChangesAsync();
        }



        public async Task<Employee> SingleOrDefaultAsync(Expression<Func<Employee, bool>> predicate)
        {
            return await _repo.SingleOrDefault(predicate);
        }

        public async Task<Employee> FirstOrDefaultAsync(Expression<Func<Employee, bool>> predicate)
        {
            return await _repo.FirstOrDefault(predicate);
        }



        public void AddRange(IEnumerable<Employee> entities)
        {
            _repo.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<Employee> entities)
        {
            await _repo.AddRangeAsync(entities);
        }

        public void UpdateRange(IEnumerable<Employee> entities)
        {
            _repo.UpdateRange(entities);
        }

        public void RemoveRange(IEnumerable<Employee> entities)
        {
            _repo.RemoveRange(entities);
        }
    }
}
