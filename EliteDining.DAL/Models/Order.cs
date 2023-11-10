using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public TimeSpan? OrderTime { get; set; }

    public int CustId { get; set; }

    public int EmployeeId { get; set; }

    public int FoodId { get; set; }

    public virtual Customer? Cust { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Food? Food { get; set; }
}
