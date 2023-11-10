using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Table
{
    public int TableNo { get; set; }

    public int? AvailableSeats { get; set; }

    public int EmployeeId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual Employee Employee { get; set; }
}
