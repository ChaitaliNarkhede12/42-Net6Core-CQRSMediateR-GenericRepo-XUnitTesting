﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCS.CQRSMediator.HandlerCommands.EmployeeCommands
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? EmailId { get; set; }
    }
}
