using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Commands;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Handlers;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Queries;
using TCCS.DataAccess;
using TCCS.DataAccess.Models;

namespace TCCS.CQRSMediator.Test.Handlers
{
    public class CreateEmployeeHandlerTest
    {
        private static IMapper _mapper;
        public CreateEmployeeHandlerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new EmployeeMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async Task CreateEmployee_Save_Sucess_Test()
        {
            var employee = new Employee() { Id = 1, Name = "Test", EmailId = "Test"};
            var mockEmpRepo = new Mock<IEmployeeRepository>();
            mockEmpRepo.Setup(x => x.AddAsync(employee)).ReturnsAsync(employee);

            //mockEmpRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var handler = new CreateEmployeeHandler(mockEmpRepo.Object, _mapper);

            var result = await handler.Handle(new CreateEmployeeCommand("test", "test"),default(CancellationToken));

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateEmployee_Save_UnSucess_Test()
        {
            var employee = new Employee() { Id = 1, Name = "Test", EmailId = "Test"};

            var mockEmpRepo = new Mock<IEmployeeRepository>();
            mockEmpRepo.Setup(x => x.AddAsync(employee)).ReturnsAsync(employee);

            mockEmpRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(0);

            var handler = new CreateEmployeeHandler(mockEmpRepo.Object, _mapper);

            var result = await handler.Handle(new CreateEmployeeCommand("test", "test"), default(CancellationToken));

            Assert.Null(result);
        }
    }
}
