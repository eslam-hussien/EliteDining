using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class ManagerT
{
    public int ManagerId { get; set; }

    public string MName { get; set; } = null!;

    public int? Salary { get; set; }

    public virtual ICollection<EmployeeT> EmployeeTs { get; set; } = new List<EmployeeT>();
}
