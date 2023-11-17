using EliteDining.APIs.ViewModel;
using EliteDining.APIs.ViewModels;
using EliteDining.BL.IServices;
using EliteDining.DAL.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EliteDining.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {


        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpPost]
        public async Task<IResult> Create(BookingViewModel bookingViewModel)
        {

            try
            {
                var isSaved = await _bookingService.AddBooking(bookingViewModel.phone, bookingViewModel.Persons, bookingViewModel.FromDate);
                if (isSaved == 1)
                {
                    return TypedResults.Ok(new ResponseModel
                    {
                        Success = true,
                        Message="Booking Done",
                        StatusCode=1

                    });
                }

                if (isSaved == -1)
                {
                    return TypedResults.Ok(new ResponseModel
                    {
                        Success = false,
                        Message="Customer isnot Found",
                        StatusCode=-1
                    });
                }
                if (isSaved == -2)
                {
                    return TypedResults.Ok(new ResponseModel
                    {
                        Success = false,
                        Message = "Tables is not available",
                        StatusCode = -2
                    });
                }
                if (isSaved == -3)
                {
                    return TypedResults.Ok(new ResponseModel
                    {
                        Success = false,
                        Message = "Reservation is not available at this time",
                        StatusCode = -3
                    });
                }
                return TypedResults.BadRequest(new ResponseModel
                {
                    Success = false,
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
