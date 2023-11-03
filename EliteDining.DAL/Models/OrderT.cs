using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class OrderT
{
    public TimeSpan? OrderTime { get; set; }

    public int CustId { get; set; }

    public int WaiterId { get; set; }

    public int FoodId { get; set; }

    public virtual CustomerT Cust { get; set; } = null!;

    public virtual FoodT Food { get; set; } = null!;

    public virtual WaiterT Waiter { get; set; } = null!;
}
