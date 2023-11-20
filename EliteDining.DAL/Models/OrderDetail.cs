using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class OrderDetail
{
    public int DetailId { get; set; }

    public int Quantity { get; set; }

    public int? FkOrderId { get; set; }

    public int? FkFoodId { get; set; }

    public virtual Food? FkFood { get; set; }

    public virtual Order? FkOrder { get; set; }
}
