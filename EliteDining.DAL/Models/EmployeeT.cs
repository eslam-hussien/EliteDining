using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class EmployeeT
{
    public int EmployeeId { get; set; }

    public string EName { get; set; } = null!;

    public DateTime? DateHired { get; set; }

    public int? HourlyPay { get; set; }

    public int ManagerId { get; set; }

    public virtual ManagerT Manager { get; set; } = null!;
}
