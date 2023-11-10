using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;

namespace EliteDining.BL.Services
{
    public class CustomerService : IGenericService<Customer>
    {
        private readonly IGenericRepo<Customer> _CustomerRepo;
        public CustomerService(IGenericRepo<Customer> CustomerRepo) =>
            _CustomerRepo = CustomerRepo;


        public Task<int> AddAsync(Customer entity) =>
             _CustomerRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _CustomerRepo.Delete(id);


        public Task<IEnumerable<Customer>> GetAllAsync() =>
             _CustomerRepo.GetAll();


        public Task<Customer> GetByIdAsync(int id) =>
             _CustomerRepo.GetOne(x => x.CustId == id);


        public Task<int> UpdateAsync(Customer entity) =>
            _CustomerRepo.Update(entity);
    }
}
