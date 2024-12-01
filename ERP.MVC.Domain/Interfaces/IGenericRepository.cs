using System.Linq.Expressions;

namespace ERP.MVC.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(CancellationToken cancellationToken, string id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(CancellationToken cancellationToken, string id);
        Task IsDeleteAsync(CancellationToken cancellationToken, string id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes);
    }
}
