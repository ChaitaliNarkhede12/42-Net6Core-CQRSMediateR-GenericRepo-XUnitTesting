using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Queries;
using TCCS.DataAccess;

namespace TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeModel>>
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IMapper _mapper;
        public GetEmployeeListHandler(IEmployeeRepository empRepo, IMapper mapper)
        {
            _empRepo = empRepo;
            _mapper = mapper;
        }

        public async Task<List<EmployeeModel>> Handle(GetEmployeeListQuery query, CancellationToken cancellationToken)
        {
            var res = await _empRepo.GetAll();
            var data = _mapper.Map<List<EmployeeModel>>(res);
            return data;
        }
    }
}
