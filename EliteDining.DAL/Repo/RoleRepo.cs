﻿using EliteDining.DAL.IRepo;
using System.Linq.Expressions;

namespace EliteDining.DAL.Repo
{ 
    public class RoleRepo : IRoleRepo
    {
        public Task<IResponseModel> AddRole(DAL.Models.Role Role)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseModel> DeleteRole(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseDataModel<IEnumerable<DAL.Models.Role>>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Task<IResponseDataModel<DAL.Models.Role>> GetRole(Expression<Func<DAL.Models.Role, bool>>? filter)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseModel> UpdateRole(DAL.Models.Role Role)
        {
            throw new NotImplementedException();
        }
    }
}