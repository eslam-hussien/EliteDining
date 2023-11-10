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
    public class RoleController : ControllerBase
    {


        private readonly IGenericService<Role> _RoleService;
        private readonly IMapper _mapper;

        public RoleController(IGenericService<Role> RoleService, IMapper mapper)
        {
            _RoleService = RoleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            try
            {
                var Roles = await _RoleService.GetAllAsync();
                if (Roles != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<IEnumerable<RoleViewModel>>
                    {
                        Success = true,
                        Data = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(Roles)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<RoleViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<RoleViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetRole(int id)
        {
            try
            {
                var Role = await _RoleService.GetByIdAsync(id);
                if (Role != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<RoleViewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Role, RoleViewModel>(Role)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<RoleViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<RoleViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(RoleViewModel roleViewModel)
        {
            var Role = _mapper.Map<RoleViewModel, Role>(roleViewModel);
            try
            {
                var isSaved = await _RoleService.AddAsync(Role);
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
        public async Task<IResult> Update(int id, RoleViewModel roleViewModel)
        {
            var Role = _mapper.Map<RoleViewModel, Role>(roleViewModel);


            if (id == roleViewModel.RoleId)
            {

                var existingRole = await _RoleService.GetByIdAsync(id);
                if (existingRole != null)
                {
                    await _RoleService.UpdateAsync(Role);
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
                    Message = "The Role ID in the URL does not match the Role ID in the body"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var Role = await _RoleService.GetByIdAsync(id);
                if (Role != null)
                {
                    await _RoleService.DeleteAsync(id);
                    return TypedResults.Ok(new ResponseDataModel<RoleViewModel>
                    {
                        Success = true,
                    });
                }
                return TypedResults.NotFound(new ResponseDataModel<RoleViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<RoleViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }



        }
    }
}
