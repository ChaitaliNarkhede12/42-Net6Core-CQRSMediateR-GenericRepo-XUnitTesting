using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Queries;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands;
using TCCS.DataAccess.Models;
using TCCS.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace TCCS.WebAPI.Tests.Controller
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IMediator> mockMediator;

        public EmployeeControllerTest()
        {
            mockMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task GetList_ReturnOkResult()
        {
            var employeeController = new EmployeeController(mockMediator.Object);

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeListQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(GetEmplopyeeList()));

            var res = await employeeController.Get();
            Assert.NotNull(res);
            Assert.Equal(((Microsoft.AspNetCore.Mvc.ObjectResult)res).StatusCode, 200);
            Assert.IsType<OkObjectResult>(res);
            //Assert.Equal(((Microsoft.AspNetCore.Mvc.ObjectResult)res).Value);
        }

        [Fact]
        public async Task GetById_ReturnOkResult()
        {
            var employeeController = new EmployeeController(mockMediator.Object);

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeListQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(GetEmplopyeeList()));

            var res = await employeeController.Get(1);
            Assert.NotNull(res);
            Assert.Equal(((Microsoft.AspNetCore.Mvc.ObjectResult)res).StatusCode, 200);
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public async Task GetByExpression_ReturnOkResult()
        {
            var employeeController = new EmployeeController(mockMediator.Object);

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeListQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(GetEmplopyeeList()));

            var res = await employeeController.GetByExpression(1);
            Assert.NotNull(res);
            Assert.Equal(((Microsoft.AspNetCore.Mvc.ObjectResult)res).StatusCode, 200);
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public async Task AddEmployeeAsync_ReturnOkResult()
        {
            var employeeController = new EmployeeController(mockMediator.Object);

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeListQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(GetEmplopyeeList()));

            EmployeeModel employee = new EmployeeModel()
            { Id = 1, Name = "Test", EmailId = "Test"};

            var res = await employeeController.AddAsync(employee);
            Assert.NotNull(res);
            Assert.Equal(((Microsoft.AspNetCore.Mvc.ObjectResult)res).StatusCode, 200);
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public async Task AddEmployeeAsync_ReturnBadRequest()
        {
            var employeeController = new EmployeeController(mockMediator.Object);

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeListQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(GetEmplopyeeList()));

            EmployeeModel employee = null;

            var res = await employeeController.AddAsync(employee);
            Assert.NotNull(res);
            Assert.Equal(((Microsoft.AspNetCore.Mvc.StatusCodeResult)res).StatusCode, 400);
            Assert.IsType<BadRequestResult>(res);
        }

        [Fact]
        public async Task UpdateEmployee_ReturnOkResult()
        {
            var employeeController = new EmployeeController(mockMediator.Object);

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeListQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(GetEmplopyeeList()));

            EmployeeModel employee = new EmployeeModel()
            { Id = 1, Name = "Test", EmailId = "Test"};

            var res = await employeeController.Update(employee);
            Assert.NotNull(res);
            Assert.Equal(((Microsoft.AspNetCore.Mvc.ObjectResult)res).StatusCode, 200);
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public async Task UpdateEmployee_ReturnBadRequest()
        {
            var employeeController = new EmployeeController(mockMediator.Object);

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeListQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(GetEmplopyeeList()));

            EmployeeModel employee = null;

            var res = await employeeController.Update(employee);
            Assert.NotNull(res);
            Assert.Equal(((Microsoft.AspNetCore.Mvc.StatusCodeResult)res).StatusCode, 400);
            Assert.IsType<BadRequestResult>(res);
        }

        [Fact]
        public async Task RemoveEmployee_ReturnOkResult()
        {
            var employeeController = new EmployeeController(mockMediator.Object);

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeListQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(GetEmplopyeeList()));

            var res = await employeeController.RemoveAsync(1);
            Assert.NotNull(res);
            Assert.Equal(((Microsoft.AspNetCore.Mvc.ObjectResult)res).StatusCode, 200);
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public async Task RemoveEmployee_ReturnBadRequest()
        {
            var employeeController = new EmployeeController(mockMediator.Object);

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeListQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(GetEmplopyeeList()));

            var res = await employeeController.RemoveAsync(0);
            Assert.NotNull(res);
            Assert.Equal(((Microsoft.AspNetCore.Mvc.StatusCodeResult)res).StatusCode, 400);
            Assert.IsType<BadRequestResult>(res);
        }




        #region

        private List<EmployeeModel> GetEmplopyeeList()
        {
            List<EmployeeModel> list = new List<EmployeeModel>()
            {
                new EmployeeModel{Id=1,Name="Test",EmailId="Test"}
            };
            return list;
        }

        private EmployeeModel GetEmplopyeeById()
        {
            EmployeeModel employee = new EmployeeModel()
            { Id = 1, Name = "Test", EmailId = "Test" };

            return employee;
        }

        #endregion
    }
}
