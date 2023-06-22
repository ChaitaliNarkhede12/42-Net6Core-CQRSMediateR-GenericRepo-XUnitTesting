using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Handlers;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Queries;
using TCCS.DataAccess;
using TCCS.DataAccess.Models;

namespace TCCS.CQRSMediator.Test.Handlers
{
    public class GetEmployeeByIdHandlerTest
    {
        private static IMapper _mapper;
        public GetEmployeeByIdHandlerTest()
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
        public async Task GetEmployeeByIdTest()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.GetById(1)).ReturnsAsync(GetEmplopyee());

            var handler = new GetEmployeeByIdHandler(mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetEmployeeByIdQuery() { Id=1}, default(CancellationToken));

            Assert.NotNull(result);
            Assert.Equal(result.Name,"Test");
        }



        private Employee GetEmplopyee()
        {
            Employee emp = new Employee()
            {
                Id=1,Name="Test",EmailId="Test"
            };
            return emp;
        }
    }
}
