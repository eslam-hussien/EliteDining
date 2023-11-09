using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EliteDining.DAL.Repo
{
    public class FoodRepo : IGenericRepo<Food>
    {
        private readonly EliteDiningDbContext _context;

        public FoodRepo(EliteDiningDbContext context) =>
            _context = context;

        public async Task<int> Add(Food entity)
        {
            _context.Foods.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var deletedOne = await GetOne(x => x.FoodId == id);
            _context.Foods.Remove(deletedOne);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Food>> GetAll() =>
              await _context.Foods.ToListAsync();


        public async Task<Food> GetOne(Expression<Func<Food, bool>> filter) =>
              await _context.Foods.FirstOrDefaultAsync(filter);

        public async Task<int> Update(Food food)
        {
            


            var existing_Food = _context.Foods.Find(food.FoodId);
            _context.Entry(existing_Food).CurrentValues.SetValues(food);
            return await _context.SaveChangesAsync();
        }
    }
}
