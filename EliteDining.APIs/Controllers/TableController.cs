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
    public class TableController : ControllerBase
    {


        private readonly IGenericService<Table> _TableService;
        private readonly IMapper _mapper;

        public TableController(IGenericService<Table> TableService, IMapper mapper)
        {
            _TableService = TableService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            try
            {
                var Tables = await _TableService.GetAllAsync();
                if (Tables != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<IEnumerable<TableViewModel>>
                    {
                        Success = true,
                        Data = _mapper.Map<IEnumerable<Table>, IEnumerable<TableViewModel>>(Tables)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<TableViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<TableViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetTable(int id)
        {
            try
            {
                var Table = await _TableService.GetByIdAsync(id);
                if (Table != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<TableViewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Table, TableViewModel>(Table)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<TableViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<TableViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(TableViewModel tableViewModel)
        {
            var Table = _mapper.Map<TableViewModel, Table>(tableViewModel);
            try
            {
                var isSaved = await _TableService.AddAsync(Table);
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
        public async Task<IResult> Update(int id, TableViewModel tableViewModel)
        {
            var Table = _mapper.Map<TableViewModel, Table>(tableViewModel);


            if (id == tableViewModel.TableNo)
            {

                var existingTable = await _TableService.GetByIdAsync(id);
                if (existingTable != null)
                {
                    await _TableService.UpdateAsync(Table);
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
                    Message = "The Table ID in the URL does not match the Table ID in the body"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var Table = await _TableService.GetByIdAsync(id);
                if (Table != null)
                {
                    await _TableService.DeleteAsync(id);
                    return TypedResults.Ok(new ResponseDataModel<TableViewModel>
                    {
                        Success = true,
                    });
                }
                return TypedResults.NotFound(new ResponseDataModel<TableViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<TableViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }



        }
    }
}
