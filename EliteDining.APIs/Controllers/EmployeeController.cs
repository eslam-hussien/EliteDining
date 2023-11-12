using AutoMapper;
using EliteDining.APIs.ViewModel;
using EliteDining.BL.IServices;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EliteDining.APIs.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {


        private readonly IGenericService<Employee> _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IGenericService<Employee> employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            try
            {
                var employees = await _employeeService.GetAllAsync();
                if (employees != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<IEnumerable<EmployeeViewModel>>
                    {
                        Success = true,
                        Data = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<EmployeeViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<EmployeeViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<EmployeeViewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Employee, EmployeeViewModel>(employee)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<EmployeeViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<EmployeeViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
            try
            {
                var isSaved = await _employeeService.AddAsync(employee);
                if (isSaved == 1)
                {
                    return TypedResults.Ok(new ResponseModel
                    {
                        Success = true,

                    });
                }
                return TypedResults.BadRequest(new ResponseModel
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseModel
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IResult> Update(int id, EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);


            if (id == employeeViewModel.EmployeeId)
            {

                var existingEmployee = await _employeeService.GetByIdAsync(id);
                if (existingEmployee != null)
                {
                    await _employeeService.UpdateAsync(employee);
                    return TypedResults.Ok(new ResponseModel
                    {
                        Success = true,
                    });
                }
                else
                {
                    return TypedResults.NotFound(new ResponseModel
                    {
                        Success = false,
                        Message = "There is no result"
                    });
                }
            }
            else
            {
                return TypedResults.BadRequest(new ResponseModel
                {
                    Success = false,
                    Message = "The employee ID in the URL does not match the employee ID in the body"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee != null)
                {
                    await _employeeService.DeleteAsync(id);
                    return TypedResults.Ok(new ResponseDataModel<EmployeeViewModel>
                    {
                        Success = true,
                    });
                }
                return TypedResults.NotFound(new ResponseDataModel<EmployeeViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<EmployeeViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }



        }
    }
}
