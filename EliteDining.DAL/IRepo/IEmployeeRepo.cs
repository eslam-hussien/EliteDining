using EliteDining.DAL.Models;
using System.Linq.Expressions;

namespace EliteDining.DAL.IRepo
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(Expression<Func<Employee, bool>>? filter);
        Task<int> AddEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(int id);
    }
}
