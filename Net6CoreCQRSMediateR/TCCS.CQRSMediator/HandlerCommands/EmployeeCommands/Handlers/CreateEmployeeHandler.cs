using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Commands;
using TCCS.DataAccess;
using TCCS.DataAccess.Models;

namespace TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeModel>
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IEmployeeRepository empRepo, IMapper mapper)
        {
            _empRepo = empRepo;
            _mapper = mapper;
        }

        public async Task<EmployeeModel> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = new Employee()
            {
                Name = command.Name,
                EmailId = command.EmailId
            };

            var res = await _empRepo.AddAsync(employee);

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
