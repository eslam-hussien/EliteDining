using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string CName { get; set; }

    public string Phone { get; set; }

    public int TableNo { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Table TableNoNavigation { get; set; } = null!;
}
