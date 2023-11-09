using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class PaymentRepo : IGenericRepo<Payment>
    {
        private readonly EliteDiningDbContext _context;

        public PaymentRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Payment entity)
        {
            _context.Payments.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.PaymentNo == id);
            _context.Payments.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payment>> GetAll() =>
              await _context.Payments.ToListAsync();


        public async Task<Payment> GetOne(Expression<Func<Payment, bool>> filter) =>
              await _context.Payments.FirstOrDefaultAsync(filter);

        public async Task<int> Update(Payment Payment)
        {
            var existing_Payment = _context.Payments.Find(Payment.PaymentNo);
            _context.Entry(existing_Payment).CurrentValues.SetValues(Payment);
            return await _context.SaveChangesAsync();
        }
    }
}
