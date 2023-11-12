using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EliteDining.DAL.Repo
{
    public class RoleRepo : IGenericRepo<EmployeeRole>
    {
        private readonly EliteDiningDbContext _context;
        public RoleRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(EmployeeRole entity)
        {
            _context.EmployeeRoles.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.RoleId == id);
            _context.EmployeeRoles.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeRole>> GetAll() =>
              await _context.EmployeeRoles.ToListAsync();

        public  async Task<EmployeeRole> GetOne(Expression<Func<EmployeeRole, bool>> filter) =>        
            await _context.EmployeeRoles.FirstOrDefaultAsync(filter);


        public async Task<int> Update(EmployeeRole role)
        {
            role.RoleName = role.RoleName;
            role.IsChef = role.IsChef;
            role.IsAdmin = role.IsAdmin;
            role.IsWaiter = role.IsWaiter;
            return await _context.SaveChangesAsync();
        }
    }
}
