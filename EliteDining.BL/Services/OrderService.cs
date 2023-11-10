using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;

namespace EliteDining.BL.Services
{
    public class OrderService : IGenericService<Order>
    {
        private readonly IGenericRepo<Order> _OrderRepo;
        public OrderService(IGenericRepo<Order> OrderRepo) =>
            _OrderRepo = OrderRepo;


        public Task<int> AddAsync(Order entity) =>
             _OrderRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _OrderRepo.Delete(id);


        public Task<IEnumerable<Order>> GetAllAsync() =>
             _OrderRepo.GetAll();


        public Task<Order> GetByIdAsync(int id) =>
             _OrderRepo.GetOne(x => x.OrderId == id);


        public Task<int> UpdateAsync(Order entity) =>
            _OrderRepo.Update(entity);
    }
}
