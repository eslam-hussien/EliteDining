using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class TableT
{
    public int TableNo { get; set; }

    public int? AvailableSeats { get; set; }

    public int WaiterId { get; set; }

    public virtual ICollection<CustomerT> CustomerTs { get; set; } = new List<CustomerT>();

    public virtual WaiterT Waiter { get; set; } = null!;
}
