using EliteDining.BL.IServices;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using System.Linq.Expressions;

namespace EliteDining.BL.Services
{
    public class RoleService : IGenericService<Role>
    {
        public Task<int> AddAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
