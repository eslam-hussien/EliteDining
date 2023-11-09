using EliteDining.DAL.Models;
using System.Linq.Expressions;

namespace EliteDining.DAL.IRepo
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(Expression<Func<T, bool>> filter);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
    }
}
