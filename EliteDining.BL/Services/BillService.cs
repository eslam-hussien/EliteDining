using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;

namespace EliteDining.BL.Services
{
    public class BillService : IGenericService<Bill>
    {

        private readonly IGenericRepo<Bill> _BillRepo;
        public BillService(IGenericRepo<Bill> BillRepo) =>
            _BillRepo = BillRepo;


        public Task<int> AddAsync(Bill entity) =>
             _BillRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _BillRepo.Delete(id);


        public Task<IEnumerable<Bill>> GetAllAsync() =>
             _BillRepo.GetAll();


        public Task<Bill> GetByIdAsync(int id) =>
             _BillRepo.GetOne(x => x.BillNo == id);


        public Task<int> UpdateAsync(Bill entity) =>
            _BillRepo.Update(entity);
    }
}
