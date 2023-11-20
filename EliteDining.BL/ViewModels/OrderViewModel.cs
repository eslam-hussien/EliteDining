namespace EliteDining.APIs.ViewModel
{
    public class OrderViewModel
    {
        public int CustomerId { get; set; }
        public List<OrderDetailViewModel> OrderList { get; set; }
    }

    public class OrderDetailViewModel
    {
        public int FoodId { get; set; }
        public int Quantity { get; set; }
    }
}
