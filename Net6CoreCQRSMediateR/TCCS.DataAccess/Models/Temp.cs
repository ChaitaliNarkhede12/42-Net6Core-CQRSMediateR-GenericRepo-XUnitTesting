using System;
using System.Collections.Generic;

namespace TCCS.DataAccess.Models;

public partial class Temp
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EmailId { get; set; }

    public string? Gender { get; set; }

    public string? MobileNumber { get; set; }

    public int? Salary { get; set; }
}
