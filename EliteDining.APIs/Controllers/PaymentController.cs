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
    public class PaymentController : ControllerBase
    {


        private readonly IGenericService<Payment> _PaymentService;
        private readonly IMapper _mapper;

        public PaymentController(IGenericService<Payment> PaymentService, IMapper mapper)
        {
            _PaymentService = PaymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            try
            {
                var Payments = await _PaymentService.GetAllAsync();
                if (Payments != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<IEnumerable<PaymentViewModel>>
                    {
                        Success = true,
                        Data = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentViewModel>>(Payments)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<PaymentViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<PaymentViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetPayment(int id)
        {
            try
            {
                var Payment = await _PaymentService.GetByIdAsync(id);
                if (Payment != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<PaymentViewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Payment, PaymentViewModel>(Payment)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<PaymentViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<PaymentViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(PaymentViewModel paymentViewModel)
        {
            var Payment = _mapper.Map<PaymentViewModel, Payment>(paymentViewModel);
            try
            {
                var isSaved = await _PaymentService.AddAsync(Payment);
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
        public async Task<IResult> Update(int id, PaymentViewModel paymentViewModel)
        {
            var Payment = _mapper.Map<PaymentViewModel, Payment>(paymentViewModel);


            if (id == paymentViewModel.PaymentNo)
            {

                var existingPayment = await _PaymentService.GetByIdAsync(id);
                if (existingPayment != null)
                {
                    await _PaymentService.UpdateAsync(Payment);
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
                    Message = "The Payment ID in the URL does not match the Payment ID in the body"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var Payment = await _PaymentService.GetByIdAsync(id);
                if (Payment != null)
                {
                    await _PaymentService.DeleteAsync(id);
                    return TypedResults.Ok(new ResponseDataModel<PaymentViewModel>
                    {
                        Success = true,
                    });
                }
                return TypedResults.NotFound(new ResponseDataModel<PaymentViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<PaymentViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }



        }
    }
}
