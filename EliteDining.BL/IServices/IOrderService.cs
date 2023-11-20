using EliteDining.APIs.ViewModel;

namespace EliteDining.BL.IServices
{
    public interface IOrderService
    {
        Task<int> AddOrder(OrderViewModel entity);

    }
}