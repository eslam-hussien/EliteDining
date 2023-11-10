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
    public class OrderController : ControllerBase
    {


        private readonly IGenericService<Order> _OrderService;
        private readonly IMapper _mapper;

        public OrderController(IGenericService<Order> OrderService, IMapper mapper)
        {
            _OrderService = OrderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            try
            {
                var Orders = await _OrderService.GetAllAsync();
                if (Orders != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<IEnumerable<OrderViewModel>>
                    {
                        Success = true,
                        Data = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(Orders)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<OrderViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<OrderViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetOrder(int id)
        {
            try
            {
                var Order = await _OrderService.GetByIdAsync(id);
                if (Order != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<OrderViewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Order, OrderViewModel>(Order)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<OrderViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<OrderViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(OrderViewModel orderViewModel)
        {
            var Order = _mapper.Map<OrderViewModel, Order>(orderViewModel);
            try
            {
                var isSaved = await _OrderService.AddAsync(Order);
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
        public async Task<IResult> Update(int id, OrderViewModel orderViewModel)
        {
            var Order = _mapper.Map<OrderViewModel, Order>(orderViewModel);


            if (id == orderViewModel.OrderId)
            {

                var existingOrder = await _OrderService.GetByIdAsync(id);
                if (existingOrder != null)
                {
                    await _OrderService.UpdateAsync(Order);
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
                    Message = "The Order ID in the URL does not match the Order ID in the body"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var Order = await _OrderService.GetByIdAsync(id);
                if (Order != null)
                {
                    await _OrderService.DeleteAsync(id);
                    return TypedResults.Ok(new ResponseDataModel<OrderViewModel>
                    {
                        Success = true,
                    });
                }
                return TypedResults.NotFound(new ResponseDataModel<OrderViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<OrderViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }



        }
    }
}
