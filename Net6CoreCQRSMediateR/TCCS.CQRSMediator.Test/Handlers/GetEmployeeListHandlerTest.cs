using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Handlers;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Queries;
using TCCS.DataAccess;
using Moq;
using TCCS.DataAccess.Models;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands;
using AutoMapper;

namespace TCCS.CQRSMediator.Test.Handlers
{
    public class GetEmployeeListHandlerTest
    {
        private static IMapper _mapper;
        public GetEmployeeListHandlerTest()
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
        public async Task GetListsTest()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(GetEmplopyeeList());

            var handler = new GetEmployeeListHandler(mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetEmployeeListQuery(), CancellationToken.None);
            Assert.NotNull(result);
        }






        private IEnumerable<Employee> GetEmplopyeeList()
        {
            List<Employee> list = new List<Employee>()
            {
                new Employee{Id=1,Name="Test",EmailId="Test"}
            };
            return list;
        }
    }
}
