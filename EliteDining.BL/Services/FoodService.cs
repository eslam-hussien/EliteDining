using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;

namespace EliteDining.BL.Services
{
    public class FoodService : IGenericService<Food>
    {
        private readonly IGenericRepo<Food> _FoodRepo;
        public FoodService(IGenericRepo<Food> FoodRepo) =>
            _FoodRepo = FoodRepo;


        public Task<int> AddAsync(Food entity) =>
             _FoodRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _FoodRepo.Delete(id);


        public Task<IEnumerable<Food>> GetAllAsync() =>
             _FoodRepo.GetAll();


        public Task<Food> GetByIdAsync(int id) =>
             _FoodRepo.GetOne(x => x.FoodId == id);


        public Task<int> UpdateAsync(Food entity) =>
            _FoodRepo.Update(entity);
    }
}

