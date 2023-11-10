using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class EmployeeRepo : IGenericRepo<Employee>
    {
        private readonly EliteDiningDbContext _context;

        public EmployeeRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Employee entity)
        {
            _context.Employees.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.EmployeeId == id);
            _context.Employees.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll() =>
              await _context.Employees.ToListAsync();


        public async Task<Employee> GetOne(Expression<Func<Employee, bool>> filter) =>
              await _context.Employees.FirstOrDefaultAsync(filter);

        public async Task<int> Update(Employee employee)
        {
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
            existingEmployee.HourlyPay = employee.HourlyPay;
            existingEmployee.DateHired = employee.DateHired;
            existingEmployee.EName = employee.EName;
            existingEmployee.RoleId = employee.RoleId;
            _context.Employees.Update(existingEmployee);
            return await _context.SaveChangesAsync();
        }
    }
}
