using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeModel>
    {
        public int Id { get; set; }
    }
}
