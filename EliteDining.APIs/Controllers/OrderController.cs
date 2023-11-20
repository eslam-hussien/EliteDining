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


        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService OrderService, IMapper mapper)
        {
            _OrderService = OrderService;
            _mapper = mapper;
        }




        [HttpPost]
        public async Task<IResult> Create(OrderViewModel orderViewModel)
        {

            try
            {
                var isSaved = await _OrderService.AddOrder(orderViewModel);
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






    }
}

