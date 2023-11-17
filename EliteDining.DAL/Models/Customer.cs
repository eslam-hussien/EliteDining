using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string? CName { get; set; }

    public string? Phone { get; set; }

    public string? Mail { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
