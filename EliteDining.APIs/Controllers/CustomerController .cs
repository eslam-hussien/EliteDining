using AutoMapper;
using EliteDining.APIs.ViewModel;
using EliteDining.BL.IServices;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EliteDining.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerController : ControllerBase
    {


        private readonly IGenericService<Customer> _CustomerService;
        private readonly IMapper _mapper;

        public CustomerController(IGenericService<Customer> CustomerService, IMapper mapper)
        {
            _CustomerService = CustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IResult> GetAll()
        {
            try
            {
                var Customers = await _CustomerService.GetAllAsync();
                if (Customers != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<IEnumerable<CustomerViewModel>>
                    {
                        Success = true,
                        Data = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(Customers)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<CustomerViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<CustomerViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetCustomer(int id)
        {
            try
            {
                var Customer = await _CustomerService.GetByIdAsync(id);
                if (Customer != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<CustomerViewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Customer, CustomerViewModel>(Customer)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<CustomerViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<CustomerViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(CustomerViewModel customerViewModel)
        {
            var Customer = _mapper.Map<CustomerViewModel, Customer>(customerViewModel);
            try
            {
                var isSaved = await _CustomerService.AddAsync(Customer);
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
        public async Task<IResult> Update(int id, CustomerViewModel customerViewModel)
        {
            var Customer = _mapper.Map<CustomerViewModel, Customer>(customerViewModel);


            if (id == customerViewModel.CustId)
            {

                var existingCustomer = await _CustomerService.GetByIdAsync(id);
                if (existingCustomer != null)
                {
                    await _CustomerService.UpdateAsync(Customer);
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
                    Message = "The Customer ID in the URL does not match the Customer ID in the body"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var Customer = await _CustomerService.GetByIdAsync(id);
                if (Customer != null)
                {
                    await _CustomerService.DeleteAsync(id);
                    return TypedResults.Ok(new ResponseDataModel<CustomerViewModel>
                    {
                        Success = true,
                    });
                }
                return TypedResults.NotFound(new ResponseDataModel<CustomerViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<CustomerViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }



        }
    }
}
