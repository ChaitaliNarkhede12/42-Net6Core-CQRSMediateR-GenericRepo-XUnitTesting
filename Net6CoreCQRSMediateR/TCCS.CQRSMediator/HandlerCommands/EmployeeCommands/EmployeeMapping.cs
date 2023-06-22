using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.CQRSMediator.HandlerCommands.EmployeeCommands.Commands;
using TCCS.DataAccess.Models;

namespace TCCS.CQRSMediator.HandlerCommands.EmployeeCommands
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping() { 
            CreateMap<EmployeeModel,Employee>().ReverseMap();
            CreateMap<CreateEmployeeCommand, Employee>().ReverseMap();
        }
    }
}
