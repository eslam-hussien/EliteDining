using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;

namespace EliteDining.BL.Services
{
    public class ContactService : IGenericService<Contact>
    {
        private readonly IGenericRepo<Contact> _ContactRepo;
        public ContactService(IGenericRepo<Contact> ContactRepo) =>
            _ContactRepo = ContactRepo;


        public Task<int> AddAsync(Contact entity) =>
             _ContactRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _ContactRepo.Delete(id);


        public Task<IEnumerable<Contact>> GetAllAsync() =>
             _ContactRepo.GetAll();


        public Task<Contact> GetByIdAsync(int id) =>
             _ContactRepo.GetOne(x => x.Id == id);


        public Task<int> UpdateAsync(Contact entity) =>
            _ContactRepo.Update(entity);
        

           
        
    }
   
}
