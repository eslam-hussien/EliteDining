using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class Bill
{
    public int BillNo { get; set; }

    public int? Amount { get; set; }

    public int CustId { get; set; }

    public virtual Customer Cust { get; set; } = null!;
}
