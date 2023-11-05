using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EliteDining.BL.Services
{
    public class EmployeeService : IGenericService<Employee>
    {

        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public Task<int> AddAsync(Employee employee) =>
             _employeeRepo.AddEmployee(employee);

        public Task<int> DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id) =>
             _employeeRepo.GetEmployee(x => x.EmployeeId == id);


        public Task<int> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
