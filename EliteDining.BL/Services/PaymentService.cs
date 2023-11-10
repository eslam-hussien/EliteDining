using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;

namespace EliteDining.BL.Services
{
    public class PaymentService : IGenericService<Payment>
    {
        private readonly IGenericRepo<Payment> _PaymentRepo;
        public PaymentService(IGenericRepo<Payment> PaymentRepo) =>
            _PaymentRepo = PaymentRepo;


        public Task<int> AddAsync(Payment entity) =>
             _PaymentRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _PaymentRepo.Delete(id);


        public Task<IEnumerable<Payment>> GetAllAsync() =>
             _PaymentRepo.GetAll();


        public Task<Payment> GetByIdAsync(int id) =>
             _PaymentRepo.GetOne(x => x.PaymentNo == id);


        public Task<int> UpdateAsync(Payment entity) =>
            _PaymentRepo.Update(entity);
    }
}
