using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace KaravanCoffeeWebAPI.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
            );

        Task<T> Get(Expression<Func<T, bool>> expression, List<string> include = null);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);
        Task SaveImage(IFormFile image,string path);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
