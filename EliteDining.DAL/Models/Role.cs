using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Role1 { get; set; } = null!;

    public bool? IsAdmin { get; set; }

    public bool? IsWaiter { get; set; }

    public bool? IsChef { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
