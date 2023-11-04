using EliteDining.DAL.Models;
using System.Linq.Expressions;

namespace EliteDining.DAL.Repo
{
    public interface IEmployee
    {
        Task<IResponseDataModel<IEnumerable<Employee>>> GetAllEmployees();
        Task<IResponseDataModel<Employee>> GetEmployee(Expression<Func<Employee, bool>>? filter);
        Task<IResponseModel> AddEmployee(Employee employee);
        Task<IResponseModel> UpdateEmployee(Employee employee);
        Task<IResponseModel> DeleteEmployee(int id);
    }
}
