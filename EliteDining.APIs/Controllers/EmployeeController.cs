using AutoMapper;
using EliteDining.APIs.ViewModel;
using EliteDining.BL.IServices;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using Microsoft.AspNetCore.Mvc;

namespace EliteDining.APIs.Controllers
{
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

        //[HttpGet]
        //public ActionResult<IEnumerable<EmployeeViewModel>> Get()
        //{
        //    var emps = _emp.GetAllEmployees;
        //    var ViewModels = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(emps);
        //    return Ok(ViewModels);
        //}

        [HttpGet("{id}")]
        public async Task<IResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<EmployeeVewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Employee, EmployeeVewModel>(employee)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<EmployeeVewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<EmployeeVewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(EmployeeVewModel employeeVewModel)
        {
            var employee = _mapper.Map<EmployeeVewModel, Employee>(employeeVewModel);
            try
            {
                var isSaved = await _employeeService.AddAsync(employee);
                if (isSaved ==1)
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

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, ProductViewModel productViewModel)
        //{
        //    if (id != productViewModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var existingProduct = _productService.GetProductById(id);
        //    if (existingProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = _mapper.Map<ProductViewModel, Product>(productViewModel);
        //    _productService.UpdateProduct(product);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var existingProduct = _productService.GetProductById(id);
        //    if (existingProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    _productService.DeleteProduct(id);

        //    return NoContent();
        //}
    }
}
