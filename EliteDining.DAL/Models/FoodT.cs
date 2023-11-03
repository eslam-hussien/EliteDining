using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class FoodT
{
    public int FoodId { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public int ChefId { get; set; }
}
