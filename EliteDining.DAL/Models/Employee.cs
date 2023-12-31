﻿using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EName { get; set; } = null!;

    public DateTime? DateHired { get; set; }

    public int? HourlyPay { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual EmployeeRole? Role { get; set; }

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}
