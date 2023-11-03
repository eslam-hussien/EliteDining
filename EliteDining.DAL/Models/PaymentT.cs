﻿using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class PaymentT
{
    public int PaymentNo { get; set; }

    public int? Amount { get; set; }

    public string? Type { get; set; }

    public int CustId { get; set; }

    public virtual CustomerT Cust { get; set; } = null!;
}