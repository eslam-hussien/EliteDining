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
    public class BillController : ControllerBase
    {


        private readonly IGenericService<Bill> _billService;
        private readonly IMapper _mapper;

        public BillController(IGenericService<Bill> billService, IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            try
            {
                var Bills = await _billService.GetAllAsync();
                if (Bills != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<IEnumerable<BillViewModel>>
                    {
                        Success = true,
                        Data = _mapper.Map<IEnumerable<Bill>, IEnumerable<BillViewModel>>(Bills)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<BillViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<BillViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetBill(int id)
        {
            try
            {
                var Bill = await _billService.GetByIdAsync(id);
                if (Bill != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<BillViewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Bill, BillViewModel>(Bill)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<BillViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<BillViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(BillViewModel billViewModel)
        {
            var Bill = _mapper.Map<BillViewModel, Bill>(billViewModel);
            try
            {
                var isSaved = await _billService.AddAsync(Bill);
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
        public async Task<IResult> Update(int id, BillViewModel billViewModel)
        {
            var Bill = _mapper.Map<BillViewModel, Bill>(billViewModel);


            if (id == billViewModel.BillNo)
            {

                var existingBill = await _billService.GetByIdAsync(id);
                if (existingBill != null)
                {
                    await _billService.UpdateAsync(Bill);
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
                    Message = "The Bill ID in the URL does not match the Bill ID in the body"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var Bill = await _billService.GetByIdAsync(id);
                if (Bill != null)
                {
                    await _billService.DeleteAsync(id);
                    return TypedResults.Ok(new ResponseDataModel<BillViewModel>
                    {
                        Success = true,
                    });
                }
                return TypedResults.NotFound(new ResponseDataModel<BillViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<BillViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }



        }
    }
}
