using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class CustomerRepo : IGenericRepo<Customer>
    {
        private readonly EliteDiningDbContext _context;

        public CustomerRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Customer entity)
        {
            _context.Customers.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.CustId == id);
            _context.Customers.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAll() =>
              await _context.Customers.ToListAsync();


        public async Task<Customer> GetOne(Expression<Func<Customer, bool>> filter) =>
              await _context.Customers.FirstOrDefaultAsync(filter);

        public async Task<int> Update(Customer customer)
        {
            


            var existing_Customer = _context.Customers.Find(customer.CustId);
            _context.Entry(existing_Customer).CurrentValues.SetValues(customer);
            return await _context.SaveChangesAsync();
        }
    }
}
