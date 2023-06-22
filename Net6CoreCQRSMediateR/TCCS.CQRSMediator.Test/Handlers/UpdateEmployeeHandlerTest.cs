using AutoMapper;
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
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands;

namespace TCCS.CQRSMediator.Test.Handlers
{
    public class UpdateEmployeeHandlerTest
    {
        private static IMapper _mapper;
        public UpdateEmployeeHandlerTest()
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
        public async Task UpdateEmployee_Save_Sucess_Test()
        {
            var employee = new Employee() { Id = 1, Name = "Test", EmailId = "Test"};

            var mockEmpRepo = new Mock<IEmployeeRepository>();
            mockEmpRepo.Setup(x => x.Update(employee)).Returns(employee);

            mockEmpRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var handler = new UpdateEmployeeHandler(mockEmpRepo.Object, _mapper);

            var result = await handler.Handle(new UpdateEmployeeCommand(1,"test", "test"), default(CancellationToken));

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateEmployee_Save_Failed_Test()
        {
            var employee = new Employee() { Id = 1, Name = "Test", EmailId = "Test" };

            var mockEmpRepo = new Mock<IEmployeeRepository>();
            mockEmpRepo.Setup(x => x.Update(employee)).Returns(employee);

            mockEmpRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(0);

            var handler = new UpdateEmployeeHandler(mockEmpRepo.Object, _mapper);

            var result = await handler.Handle(new UpdateEmployeeCommand(1, "test", "test"), default(CancellationToken));

            Assert.Null(result);
        }
    }
}
