using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class TableRepo : IGenericRepo<Table>
    {
        private readonly EliteDiningDbContext _context;

        public TableRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Table entity)
        {
            _context.Tables.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.TableNo == id);
            _context.Tables.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Table>> GetAll() =>
              await _context.Tables.ToListAsync();
        public async Task<IEnumerable<Table>> GetAllTables(Expression<Func<Table, bool>> filter) =>
             await _context.Tables.Where(filter).ToListAsync();


        public async Task<Table> GetOne(Expression<Func<Table, bool>> filter) =>
              await _context.Tables.FirstOrDefaultAsync(filter);

        public async Task<int> Update(Table Table)
        {
            var existing_Table = _context.Tables.Find(Table.TableNo);
            _context.Entry(existing_Table).CurrentValues.SetValues(Table);
            return await _context.SaveChangesAsync();
        }
    }
}
