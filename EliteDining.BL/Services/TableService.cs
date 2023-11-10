using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;

namespace EliteDining.BL.Services
{
    public class TableService : IGenericService<Table>
    {
        private readonly IGenericRepo<Table> _TableRepo;
        public TableService(IGenericRepo<Table> TableRepo) =>
            _TableRepo = TableRepo;


        public Task<int> AddAsync(Table entity) =>
             _TableRepo.Add(entity);

        public Task<int> DeleteAsync(int id) =>
             _TableRepo.Delete(id);


        public Task<IEnumerable<Table>> GetAllAsync() =>
             _TableRepo.GetAll();


        public Task<Table> GetByIdAsync(int id) =>
             _TableRepo.GetOne(x => x.TableNo == id);


        public Task<int> UpdateAsync(Table entity) =>
            _TableRepo.Update(entity);
    }
}
