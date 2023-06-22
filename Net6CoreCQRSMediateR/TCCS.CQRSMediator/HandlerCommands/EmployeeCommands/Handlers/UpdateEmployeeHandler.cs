using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Commands;
using TCCS.DataAccess.Models;
using TCCS.DataAccess;

namespace TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeModel>
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IMapper _mapper;
        public UpdateEmployeeHandler(IEmployeeRepository empRepo, IMapper mapper)
        {
            _empRepo = empRepo;
            _mapper = mapper;
        }

        public async Task<EmployeeModel> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = new Employee()
            {
                Id = command.Id,
                Name = command.Name,
                EmailId = command.EmailId
            };

            var res = _empRepo.Update(employee);

            int result = await _empRepo.SaveChangesAsync();

            if (result == 0)
            {
                return null;
            }
            else
            {
                return _mapper.Map<EmployeeModel>(res);
            }
        }
    }
}
