using EliteDining.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EliteDining.DAL.Repo
{
    public interface IRole
    {
        Task<IResponseDataModel<IEnumerable<Role>>> GetAllRoles();
        Task<IResponseDataModel<Role>> GetRole(Expression<Func<Role, bool>>? filter);
        Task<IResponseModel> AddRole(Role Role);
        Task<IResponseModel> UpdateRole(Role Role);
        Task<IResponseModel> DeleteRole(int id);
    }
}
