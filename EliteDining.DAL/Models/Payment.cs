using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Payment
{
    public int PaymentNo { get; set; }

    public int? Amount { get; set; }

    public string? Type { get; set; }

    public int CustId { get; set; }

    public virtual Customer? Cust { get; set; }
}
