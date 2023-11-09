using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EliteDining.DAL.Repo
{
    public class RoleRepo : IGenericRepo<Role>
    {
        private readonly EliteDiningDbContext _context;
        public RoleRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Role entity)
        {
            _context.Roles.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.RoleId == id);
            _context.Roles.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAll() =>
              await _context.Roles.ToListAsync();

        public  async Task<Role> GetOne(Expression<Func<Role, bool>> filter) =>        
            await _context.Roles.FirstOrDefaultAsync(filter);


        public async Task<int> Update(Role role)
        {
            role.RoleName = role.RoleName;
            role.IsChef = role.IsChef;
            role.IsAdmin = role.IsAdmin;
            role.IsWaiter = role.IsWaiter;
            return await _context.SaveChangesAsync();
        }
    }
}
