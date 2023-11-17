using AutoMapper;
using EliteDining.APIs.ViewModel;
using EliteDining.APIs.ViewModels;
using EliteDining.BL.IServices;
using EliteDining.BL.Services;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EliteDining.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {


        private readonly IGenericService<Contact> _ContactService;
        private readonly IMapper _mapper;

        public ContactController(IGenericService<Contact> ContactService, IMapper mapper)
        {
            _ContactService = ContactService;
            _mapper = mapper;
        }

        [HttpGet]
        
        public async Task<IResult> GetAll()
        {
            try
            {
                var Contacts = await _ContactService.GetAllAsync();
                if (Contacts != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<IEnumerable<ContactViewModel>>
                    {
                        Success = true,
                        Data = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(Contacts)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<ContactViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<ContactViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetContact(int id)
        {
            try
            {
                var Contact = await _ContactService.GetByIdAsync(id);
                if (Contact != null)
                {
                    return TypedResults.Ok(new ResponseDataModel<ContactViewModel>
                    {
                        Success = true,
                        Data = _mapper.Map<Contact, ContactViewModel>(Contact)

                    });
                }
                return TypedResults.BadRequest(new ResponseDataModel<ContactViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<ContactViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(ContactViewModel ContactViewModel)
        {
            var Contact = _mapper.Map<ContactViewModel, Contact>(ContactViewModel);
            try
            {
                var isSaved = await _ContactService.AddAsync(Contact);
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
        public async Task<IResult> Update(int id, ContactViewModel ContactViewModel)
        {
            var Contact = _mapper.Map<ContactViewModel, Contact>(ContactViewModel);


            
            

                var existingContact = await _ContactService.GetByIdAsync(id);
                if (existingContact != null)
                {
                    await _ContactService.UpdateAsync(Contact);
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

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var Contact = await _ContactService.GetByIdAsync(id);
                if (Contact != null)
                {
                    await _ContactService.DeleteAsync(id);
                    return TypedResults.Ok(new ResponseDataModel<ContactViewModel>
                    {
                        Success = true,
                    });
                }
                return TypedResults.NotFound(new ResponseDataModel<ContactViewModel>
                {
                    Success = false,
                    Message = "There is no result"
                });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(new ResponseDataModel<ContactViewModel>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }



        }






    }
}
