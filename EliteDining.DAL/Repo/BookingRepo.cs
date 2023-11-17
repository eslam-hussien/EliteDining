using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class BookingRepo : IGenericRepo<Booking>
    {
        private readonly EliteDiningDbContext _context;

        public BookingRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Booking entity)
        {
            _context.Bookings.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.CustId == id);
            _context.Bookings.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAll() =>
              await _context.Bookings.ToListAsync();


        public async Task<Booking> GetOne(Expression<Func<Booking, bool>> filter) =>
              await _context.Bookings.FirstOrDefaultAsync(filter);

        public async Task<int> Update(Booking Booking)
        {
            


            var existing_Booking = _context.Bookings.Find(Booking.CustId);
            _context.Entry(existing_Booking).CurrentValues.SetValues(Booking);
            return await _context.SaveChangesAsync();
        }
    }
}
