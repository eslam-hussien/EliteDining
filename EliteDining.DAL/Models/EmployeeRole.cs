using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class EmployeeRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsWaiter { get; set; }

    public bool? IsChef { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
