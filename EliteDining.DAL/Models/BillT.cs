using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class BillT
{
    public int BillNo { get; set; }

    public int? Amount { get; set; }

    public int CustId { get; set; }

    public virtual CustomerT Cust { get; set; } = null!;
}
