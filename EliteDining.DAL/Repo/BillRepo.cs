using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class BillRepo : IGenericRepo<Bill>
    {
        private readonly EliteDiningDbContext _context;

        public BillRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Bill entity)
        {
            _context.Bills.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.BillNo == id);
            _context.Bills.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bill>> GetAll() =>
              await _context.Bills.ToListAsync();


        public async Task<Bill> GetOne(Expression<Func<Bill, bool>> filter) =>
              await _context.Bills.FirstOrDefaultAsync(filter);

        public async Task<int> Update(Bill bill)
        {
            var existing_Bill = _context.Bills.Find(bill.BillNo);
            _context.Entry(existing_Bill).CurrentValues.SetValues(bill);
            return await _context.SaveChangesAsync();
        }
    }
}
