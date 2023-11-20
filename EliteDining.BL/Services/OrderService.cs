using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using EliteDining.APIs.ViewModel;

namespace EliteDining.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepo<Order> _OrderRepo;
        private readonly IGenericRepo<OrderDetail> detailRepo;

        public OrderService(IGenericRepo<Order> OrderRepo, IGenericRepo<OrderDetail> detailRepo)
        {
            _OrderRepo = OrderRepo;
            this.detailRepo = detailRepo;
        }

        public async Task<int> AddOrder(OrderViewModel entity)
        {
            try
            {
                var order = new Order
                {
                    OrderTime = DateTime.Now,
                    CustId = entity.CustomerId,

                };

               await _OrderRepo.Add(order);

                foreach (var item in entity.OrderList)
                {
                    var orderDetails = new OrderDetail
                    {
                        Quantity = item.Quantity,


                        FkOrderId = order.OrderId,


                        FkFoodId =item.FoodId,
                    };
                   await detailRepo.Add(orderDetails);

                }


                return 1;


            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }


}
