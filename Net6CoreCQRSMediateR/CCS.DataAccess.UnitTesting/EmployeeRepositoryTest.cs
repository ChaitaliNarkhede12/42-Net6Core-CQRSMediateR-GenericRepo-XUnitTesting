using Moq;
using TCCS.DataAccess;
using TCCS.DataAccess.Models;

namespace CCS.DataAccess.UnitTesting
{
    public class EmployeeRepositoryTest
    {
        [Fact]
        public async Task GetAll_ShouldReturnList()
        {
            //Arrange

            var employeeList = GetEmployeeList();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(employeeList);

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            var result = await repo.GetAll();

            //Assert
            Assert.IsAssignableFrom<List<Employee>>(result);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetEmployeeById_ShouldReturnList()
        {
            //Arrange

            var employee = GetEmployee();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.GetById(1)).ReturnsAsync(employee);

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            var result = await repo.GetById(1);

            //Assert
            Assert.IsAssignableFrom<Employee>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetEmployeeByIdByPredicate_ShouldReturnList()
        {
            //Arrange

            var employeeList = GetEmployeeList();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.GetById(x => x.Id == 1)).ReturnsAsync(employeeList);

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            var result = await repo.GetById(x => x.Id == 1);

            //Assert
            Assert.IsAssignableFrom<List<Employee>>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddEmployeeAsync_ShouldReturnList()
        {
            //Arrange

            var employee = GetEmployee();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.AddAsync(employee)).ReturnsAsync(employee);

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            var result = await repo.AddAsync(employee);

            //Assert
            Assert.IsAssignableFrom<Employee>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateEmployee_ShouldReturnList()
        {
            //Arrange

            var employee = GetEmployee();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.Update(employee)).Returns(employee);

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            var result = repo.Update(employee);

            //Assert
            Assert.IsAssignableFrom<Employee>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task RemoveEmployee_ShouldReturnList()
        {
            //Arrange

            var employee = GetEmployee();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.Remove(employee));

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            repo.Remove(employee);
        }

        [Fact]
        public async Task RemoveEmployeeById_ShouldReturnList()
        {
            //Arrange

            var employee = GetEmployee();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.RemoveById(1));

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            repo.RemoveById(1);
        }

        [Fact]
        public async Task SaveChanges_ShouldReturnList()
        {
            //Arrange

            var employee = GetEmployee();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.SaveChanges()).Returns(1);

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            var res = repo.SaveChanges();

            Assert.Equal(1, res);
        }

        [Fact]
        public async Task SaveChangesAsync_ShouldReturnList()
        {
            //Arrange

            var employee = GetEmployee();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            var res = await repo.SaveChangesAsync();

            Assert.Equal(1, res);
        }

        [Fact]
        public async Task SingleOrDefaultEmployee_ShouldReturn()
        {
            //Arrange

            var employee = GetEmployee();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.SingleOrDefault(x => x.Id == 1)).ReturnsAsync(employee);

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            var result = await repo.SingleOrDefaultAsync(x => x.Id == 1);

            Assert.IsAssignableFrom<Employee>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task FirstOrDefaultEmployee_ShouldReturn()
        {
            //Arrange

            var employee = GetEmployee();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.FirstOrDefault(x => x.Id == 1)).ReturnsAsync(employee);

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            var result = await repo.FirstOrDefaultAsync(x => x.Id == 1);

            Assert.IsAssignableFrom<Employee>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddEmployeeRange_ShouldReturn()
        {
            //Arrange

            var employeeList = GetEmployeeList();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.AddRange(employeeList));

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            repo.AddRange(employeeList);
        }

        [Fact]
        public async Task AddEmployeeRangeAsync_ShouldReturn()
        {
            //Arrange

            var employeeList = GetEmployeeList();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.AddRangeAsync(employeeList));

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            repo.AddRangeAsync(employeeList);
        }

        [Fact]
        public async Task UpdateEmployeeRange_ShouldReturn()
        {
            //Arrange

            var employeeList = GetEmployeeList();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.UpdateRange(employeeList));

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            repo.UpdateRange(employeeList);
        }

        [Fact]
        public async Task RemoveEmployeeRange_ShouldReturn()
        {
            //Arrange

            var employeeList = GetEmployeeList();


            var mockRepo = new Mock<IRepository<Employee>>();
            mockRepo.Setup(x => x.RemoveRange(employeeList));

            var repo = new EmployeeRepository(mockRepo.Object);

            //Act
            repo.RemoveRange(employeeList);
        }





        private IEnumerable<Employee> GetEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee{Id=1,Name="test1",EmailId="test1@gmail.com"},
                new Employee{Id=2,Name="test2",EmailId="test2@gmail.com"}
            };

            return employeeList;
        }

        private IEnumerable<Employee> GetEmployeeListByPredication(int id)
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee{Id=1,Name="test1",EmailId="test1@gmail.com"},
                new Employee{Id=2,Name="test2",EmailId="test2@gmail.com"}
            };

            return employeeList.Where(x => x.Id == id).ToList();
        }

        private Employee GetEmployee()
        {
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "test1",
                EmailId = "test1@gmail.com"
            };

            return employee;
        }

        private Employee AddEmployee()
        {
            Employee employee = new Employee()
            {
                Id = 0,
                Name = "abc",
                EmailId = "abc@gmail.com"
            };

            return employee;
        }
    }
}