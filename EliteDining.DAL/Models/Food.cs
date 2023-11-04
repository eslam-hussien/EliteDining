using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Food
{
    public int FoodId { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
