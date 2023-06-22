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
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeModel>
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IMapper _mapper;
        public GetEmployeeByIdHandler(IEmployeeRepository empRepo, IMapper mapper)
        {
            _empRepo = empRepo;
            _mapper = mapper;
        }

        public async Task<EmployeeModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _empRepo.GetById(request.Id);
            return _mapper.Map<EmployeeModel>(res);
        }
    }
}
