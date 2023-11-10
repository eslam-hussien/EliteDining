using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;

namespace EliteDining.BL.Services
{
    public class EmployeeService : IGenericService<Employee>
    {

        private readonly IGenericRepo<Employee> _employeeRepo;
        public EmployeeService(IGenericRepo<Employee> employeeRepo)=>
            _employeeRepo = employeeRepo;
        

        public  Task<int> AddAsync(Employee entity) =>
             _employeeRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _employeeRepo.Delete(id);
        

        public Task<IEnumerable<Employee>> GetAllAsync() =>
             _employeeRepo.GetAll();
       

        public Task<Employee> GetByIdAsync(int id) =>
             _employeeRepo.GetOne(x => x.EmployeeId == id);


        public Task<int> UpdateAsync(Employee entity) =>
            _employeeRepo.Update(entity);
        
    }
}
