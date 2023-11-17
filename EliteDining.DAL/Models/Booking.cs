using System.ComponentModel.DataAnnotations.Schema;

namespace EliteDining.DAL.Models;

public partial class Booking
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int TableNo { get; set; }

    public int CustId { get; set; }

    public virtual Customer Cust { get; set; } = null!;

    public virtual Table TableNoNavigation { get; set; } = null!;
}
