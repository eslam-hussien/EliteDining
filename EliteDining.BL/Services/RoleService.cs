using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;

namespace EliteDining.BL.Services
{
    public class RoleService : IGenericService<EmployeeRole>
    {
        private readonly IGenericRepo<EmployeeRole> _roleRepo;
        public RoleService(IGenericRepo<EmployeeRole> roleRepo) =>
            _roleRepo = roleRepo;
        public Task<int> AddAsync(EmployeeRole entity) =>
            _roleRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _roleRepo.Delete(id);

        public Task<IEnumerable<EmployeeRole>> GetAllAsync() =>
             _roleRepo.GetAll();

        public Task<EmployeeRole> GetByIdAsync(int id) =>
             _roleRepo.GetOne(x => x.RoleId == id);

        public Task<int> UpdateAsync(EmployeeRole entity) =>
            _roleRepo.Update(entity);
    }
}
