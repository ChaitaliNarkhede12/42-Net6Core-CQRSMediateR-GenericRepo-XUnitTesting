using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeModel>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? EmailId { get; set; }

        public UpdateEmployeeCommand(int id, string? name, string? email)
        {
            Id = id;
            Name = name;
            EmailId = email;
        }
    }
}
