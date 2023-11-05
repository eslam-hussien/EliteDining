using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EliteDiningDbContext _context;

        public EmployeeRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            return await _context.SaveChangesAsync();
        }

        public Task<int> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployee(Expression<Func<Employee, bool>>? filter) =>
            await _context.Employees.FirstOrDefaultAsync(filter);

        public Task<int> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
