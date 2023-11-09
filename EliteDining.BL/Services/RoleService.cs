using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using System.Linq.Expressions;

namespace EliteDining.BL.Services
{
    public class RoleService : IGenericService<Role>
    {
        private readonly IGenericRepo<Role> _roleRepo;
        public RoleService(IGenericRepo<Role> roleRepo) =>
            _roleRepo = roleRepo;
        public Task<int> AddAsync(Role entity)=>
            _roleRepo.Add(entity);

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllAsync()
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
