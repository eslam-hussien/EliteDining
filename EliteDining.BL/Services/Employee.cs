using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EliteDining.BL.Services
{
    public class Employee : IEmployee
    {
        private readonly EliteDiningDbContext _context;

        public Employee(EliteDiningDbContext context) =>
            _context = context;

        public async Task<IResponseModel> AddEmployee(DAL.Models.Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                return await _context.SaveChangesAsync() == 1 ?
                    new ResponseModel { Success = true } :
                    new ResponseModel
                    {
                        Success = false
                    };

            }
            catch (Exception e)
            {
                return new ResponseModel
                {
                    Message = e.Message,
                    Success = false

                };
            }

        }

        public Task<IResponseModel> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseDataModel<IEnumerable<DAL.Models.Employee>>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<IResponseDataModel<DAL.Models.Employee>> GetEmployee(Expression<Func<DAL.Models.Employee, bool>>? filter)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseModel> UpdateEmployee(DAL.Models.Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
