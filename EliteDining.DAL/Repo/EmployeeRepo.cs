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

        public async Task<int> DeleteEmployee(int id)
        {
            var deletedEmployee = await GetEmployee(x => x.EmployeeId == id);
            _context.Employees.Remove(deletedEmployee);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees() =>
              await _context.Employees.ToListAsync();


        public async Task<Employee> GetEmployee(Expression<Func<Employee, bool>> filter) =>
              await _context.Employees.FirstOrDefaultAsync(filter);

        public async Task<int> UpdateEmployee(Employee employee)
        {
            employee.HourlyPay = employee.HourlyPay;
            employee.DateHired = employee.DateHired;
            employee.EName = employee.EName;
            employee.RoleId = employee.RoleId;
            return await _context.SaveChangesAsync();
        }
    }
}
