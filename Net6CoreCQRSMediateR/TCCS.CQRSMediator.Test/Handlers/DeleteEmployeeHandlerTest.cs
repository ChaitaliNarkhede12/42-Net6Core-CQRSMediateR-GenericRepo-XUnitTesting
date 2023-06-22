using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Commands;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Handlers;
using TCCS.DataAccess.Models;
using TCCS.DataAccess;

namespace TCCS.CQRSMediator.Test.Handlers
{
    public class DeleteEmployeeHandlerTest
    {
        [Fact]
        public async Task RemoveEmployee_Sucess_Test()
        {
            var employee = new Employee() { Id = 1, Name = "Test", EmailId = "Test"};

            var mockEmpRepo = new Mock<IEmployeeRepository>();
            mockEmpRepo.Setup(x => x.GetById(1)).ReturnsAsync(employee);
            mockEmpRepo.Setup(x => x.Remove(employee));
            mockEmpRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var handler = new DeleteEmployeeHandler(mockEmpRepo.Object);

            var result = await handler.Handle(new DeleteEmployeeCommand() { Id=1}, default(CancellationToken));

            Assert.Equal(result,1);
        }

        [Fact]
        public async Task Sucess_Tesr()
        {
            var employee = new Employee();

            var mockEmpRepo = new Mock<IEmployeeRepository>();
            mockEmpRepo.Setup(x => x.GetById(1)).ReturnsAsync(employee);
            mockEmpRepo.Setup(x => x.Remove(employee));
            mockEmpRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var handler = new DeleteEmployeeHandler(mockEmpRepo.Object);

            var result = await handler.Handle(new DeleteEmployeeCommand() { Id = 1 }, default(CancellationToken));

            Assert.Equal(result, 1);
        }

        [Fact]
        public async Task RemoveEmployee_Failed_Test()
        {
            var employee = new Employee();

            var mockEmpRepo = new Mock<IEmployeeRepository>();
            mockEmpRepo.Setup(x => x.GetById(1)).ReturnsAsync(employee);
            mockEmpRepo.Setup(x => x.Remove(employee));
            mockEmpRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(0);

            var handler = new DeleteEmployeeHandler(mockEmpRepo.Object);

            var result = await handler.Handle(new DeleteEmployeeCommand() { Id = 1 }, default(CancellationToken));

            Assert.Equal(result, 0);
        }
    }
}
