using EliteDining.DAL.Models;

namespace EliteDining.APIs.ViewModel
{
    public class BillViewModel
    {
        public int BillNo { get; set; }

        public int? Amount { get; set; }

        public int CustId { get; set; }
    }
}
