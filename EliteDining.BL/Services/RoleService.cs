using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;

namespace EliteDining.BL.Services
{
    public class RoleService : IGenericService<Role>
    {
        private readonly IGenericRepo<Role> _roleRepo;
        public RoleService(IGenericRepo<Role> roleRepo) =>
            _roleRepo = roleRepo;
        public Task<int> AddAsync(Role entity) =>
            _roleRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _roleRepo.Delete(id);

        public Task<IEnumerable<Role>> GetAllAsync() =>
             _roleRepo.GetAll();

        public Task<Role> GetByIdAsync(int id) =>
             _roleRepo.GetOne(x => x.RoleId == id);

        public Task<int> UpdateAsync(Role entity) =>
            _roleRepo.Update(entity);
    }
}
