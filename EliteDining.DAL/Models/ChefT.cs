using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class ChefT
{
    public int ChefId { get; set; }

    public string? Station { get; set; }

    public string? DayOrNight { get; set; }

    public virtual EmployeeT Chef { get; set; } = null!;
}
