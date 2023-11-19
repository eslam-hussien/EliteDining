using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class ContactRepo : IGenericRepo<Contact>
    {
        private readonly EliteDiningDbContext _context;

        public ContactRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Contact entity)
        {
            _context.Contacts.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.Id == id);
            _context.Contacts.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> GetAll() =>
              await _context.Contacts.ToListAsync();


        public async Task<Contact> GetOne(Expression<Func<Contact, bool>> filter) =>
              await _context.Contacts.FirstOrDefaultAsync(filter);

        public async Task<int> Update(Contact Contact)
        {
            var existing_Contact = _context.Contacts.Find(Contact.Id);
            _context.Entry(existing_Contact).CurrentValues.SetValues(Contact);
            return await _context.SaveChangesAsync();
        }
    }
}
