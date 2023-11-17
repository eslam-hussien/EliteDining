using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Table
{
    public int TableNo { get; set; }

    public int? AvailableSeats { get; set; }

    public int EmployeeId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Employee Employee { get; set; } = null!;
}
