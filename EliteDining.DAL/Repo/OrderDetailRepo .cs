using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class OrderDetailRepo : IGenericRepo<OrderDetail>
    {
        private readonly EliteDiningDbContext _context;

        public OrderDetailRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(OrderDetail entity)
        {
            _context.OrderDetails.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.DetailId == id);
            _context.OrderDetails.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetAll() =>
              await _context.OrderDetails.ToListAsync();


        public async Task<OrderDetail> GetOne(Expression<Func<OrderDetail, bool>> filter) =>
              await _context.OrderDetails.FirstOrDefaultAsync(filter);

        public async Task<int> Update(OrderDetail OrderDetail)
        {
            var existing_OrderDetail = _context.OrderDetails.Find(OrderDetail.DetailId);
            _context.Entry(existing_OrderDetail).CurrentValues.SetValues(OrderDetail);
            return await _context.SaveChangesAsync();
        }
    }
}
