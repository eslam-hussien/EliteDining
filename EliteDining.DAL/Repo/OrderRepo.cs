using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class OrderRepo : IGenericRepo<Order>
    {
        private readonly EliteDiningDbContext _context;

        public OrderRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Order entity)
        {
            _context.Orders.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            /*var deletedOne = await GetOne(x => x.OrderNo == id);
            _context.Orders.Remove(deletedOne);*/
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll() =>
              await _context.Orders.ToListAsync();


        public async Task<Order> GetOne(Expression<Func<Order, bool>> filter) =>
              await _context.Orders.FirstOrDefaultAsync(filter);

        public async Task<int> Update(Order Order)
        {
           /* var existing_Order = _context.Orders.Find(Order.OrderNo);
            _context.Entry(existing_Order).CurrentValues.SetValues(Order);*/
            return await _context.SaveChangesAsync();
        }
    }
}
