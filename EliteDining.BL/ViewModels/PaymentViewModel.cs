namespace EliteDining.APIs.ViewModel
{
    public class PaymentViewModel
    {
        public int PaymentNo { get; set; }

        public int? Amount { get; set; }

        public string? Type { get; set; }

        public int CustId { get; set; }
    }
}
