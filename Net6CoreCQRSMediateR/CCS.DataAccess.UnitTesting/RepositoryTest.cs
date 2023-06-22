using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Models;
using TCCS.DataAccess;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using Microsoft.Extensions.Options;

namespace CCS.DataAccess.UnitTesting
{
    public class RepositoryTest
    {
        public TccsContext tccsContext { get; private set; }
        public DbContextOptions<TccsContext> tccsContextOptions { get; private set; }
        private const string Database = "TCCSInMemoryDatabase";

        public RepositoryTest()
        {
             tccsContextOptions = new DbContextOptionsBuilder<TccsContext>()
            .UseInMemoryDatabase(databaseName: "EmployeeTestingDB")
            .Options;

            tccsContext = new TccsContext(tccsContextOptions);

            tccsContext.Database.EnsureCreated();
            using (var context = new TccsContext(tccsContextOptions))
            {
                context.Employees.Add(new Employee { Id = 1, Name = "Test1", EmailId = "" });
                context.SaveChanges();
            }
        }


        [Fact]
        public async Task GetAll_ShouldReturn()
        {
           var repo = new Repository<Employee>(tccsContext);
                 
           var res = await repo.GetAll();

            Assert.Equal(1, res.Count());

            tccsContext.Database.EnsureDeleted();
            tccsContext.Dispose();
        }

        [Fact]
        public async Task GetById_ShouldReturn()
        {
            var repo = new Repository<Employee>(tccsContext);

            var res = await repo.GetById(1);

            Assert.NotNull(res);

            tccsContext.Database.EnsureDeleted();
            tccsContext.Dispose();
        }

        [Fact]
        public async Task GetByIdPredicate_ShouldReturn()
        {
            var repo = new Repository<Employee>(tccsContext);

            var res = await repo.GetById(x=>x.Id == 1);

            Assert.Equal(1, res.Count());

            tccsContext.Database.EnsureDeleted();
            tccsContext.Dispose();
        }

        [Fact]
        public async Task AddAsync_ShouldReturn()
        {
            var emp = new Employee { Id = 0, Name = "Test2", EmailId = "" };

            var repo = new Repository<Employee>(tccsContext);

            var res = await repo.AddAsync(emp);

            Assert.NotNull(res);
            tccsContext.Database.EnsureDeleted();
            tccsContext.Dispose();
        }

        [Fact]
        public async Task Update_ShouldReturn()
        {
            var emp = new Employee { Id = 1, Name = "Test22", EmailId = "" };

            var repo = new Repository<Employee>(tccsContext);

            var res = repo.Update(emp);

            Assert.NotNull(res);
            tccsContext.Database.EnsureDeleted();
            tccsContext.Dispose();
        }


        [Fact]
        public async Task Remove_ShouldReturn()
        {
            var emp = new Employee { Id = 1, Name = "Test22", EmailId = "" };

            var repo = new Repository<Employee>(tccsContext);

            repo.Remove(emp);
            tccsContext.Database.EnsureDeleted();
            tccsContext.Dispose();
        }

        [Fact]
        public async Task RemoveById_ShouldReturn()
        {
            var repo = new Repository<Employee>(tccsContext);

            repo.RemoveById(1);
            tccsContext.Database.EnsureDeleted();
            tccsContext.Dispose();
        }


    }
}
