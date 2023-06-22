using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Commands;
using TCCS.DataAccess;

namespace TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _empRepo;
             
        public DeleteEmployeeHandler(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }

        public async Task<int> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _empRepo.GetById(command.Id);
            if (employee == null)
            {
                return 0;
            }

            _empRepo.Remove(employee);
            int result = await _empRepo.SaveChangesAsync();

            if (result == 0)
            {
                return 0;
            }
            else
            {
                return result;
            }
        }
    }
}
