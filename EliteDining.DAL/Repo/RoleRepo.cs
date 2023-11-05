using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EliteDining.DAL.Repo
{
    public class RoleRepo : IRoleRepo
    {
        private readonly EliteDiningDbContext _context;
        public RoleRepo(EliteDiningDbContext context) =>
            _context = context;
        public Task<int> AddRole(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteRole(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRole(Expression<Func<Role, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
