using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class CustomerT
{
    public int CustId { get; set; }

    public string? CName { get; set; }

    public string? Phone { get; set; }

    public int TableNo { get; set; }

    public virtual ICollection<BillT> BillTs { get; set; } = new List<BillT>();

    public virtual ICollection<PaymentT> PaymentTs { get; set; } = new List<PaymentT>();

    public virtual TableT TableNoNavigation { get; set; } = null!;
}
