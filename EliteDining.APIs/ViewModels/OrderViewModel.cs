namespace EliteDining.APIs.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public TimeSpan? OrderTime { get; set; }

        public int CustId { get; set; }

        public int EmployeeId { get; set; }

        public int FoodId { get; set; }
    }
}
