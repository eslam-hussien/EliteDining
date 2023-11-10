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
    public class FoodController : ControllerBase
    {


        private readonly IGenericService<Food> _FoodService;
        private readonly IMapper _mapper;

        public FoodController(IGenericService<Food> FoodService, IMapper mapper)
        {
            _FoodService = FoodService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            try
            {
                var Foods = await _FoodService.GetAllAsync();
                if (Foods != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<IEnumerable<FoodViewModel>>
                    {
                        Success = true,
                        Data = _mapper.Map<IEnumerable<Food>, IEnumerable<FoodViewModel>>(Foods)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<FoodViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<FoodViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetFood(int id)
        {
            try
            {
                var Food = await _FoodService.GetByIdAsync(id);
                if (Food != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<FoodViewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Food, FoodViewModel>(Food)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<FoodViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<FoodViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(FoodViewModel FoodViewModel)
        {
            var Food = _mapper.Map<FoodViewModel, Food>(FoodViewModel);
            try
            {
                var isSaved = await _FoodService.AddAsync(Food);
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
        public async Task<IResult> Update(int id, FoodViewModel foodViewModel)
        {
            var Food = _mapper.Map<FoodViewModel, Food>(foodViewModel);


            if (id == foodViewModel.FoodId)
            {

                var existingFood = await _FoodService.GetByIdAsync(id);
                if (existingFood != null)
                {
                    await _FoodService.UpdateAsync(Food);
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
                    Message = "The Food ID in the URL does not match the Food ID in the body"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var Food = await _FoodService.GetByIdAsync(id);
                if (Food != null)
                {
                    await _FoodService.DeleteAsync(id);
                    return TypedResults.Ok(new ResponseDataModel<FoodViewModel>
                    {
                        Success = true,
                    });
                }
                return TypedResults.NotFound(new ResponseDataModel<FoodViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<FoodViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }



        }
    }
}
