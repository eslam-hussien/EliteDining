using System;
using System.Collections.Generic;

namespace EliteDining.DAL.Models;

public partial class WaiterT
{
    public int WaiterId { get; set; }

    public int? Tips { get; set; }

    public virtual ICollection<TableT> TableTs { get; set; } = new List<TableT>();
}
