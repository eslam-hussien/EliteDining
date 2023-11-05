using EliteDining.DAL.Models;
using System.Linq.Expressions;

namespace EliteDining.DAL.IRepo
{
    public interface IRoleRepo
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRole(Expression<Func<Role, bool>> filter);
        Task<int> AddRole(Role role);
        Task<int> UpdateRole(Role role);
        Task<int> DeleteRole(int id);
    }
}
