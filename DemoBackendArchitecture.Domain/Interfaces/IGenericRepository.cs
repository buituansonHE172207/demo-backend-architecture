using System.Linq.Expressions;

namespace DemoBackendArchitecture.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    public Task AddAsync(T entity, CancellationToken token);
    public Task AddRangeAsync(IEnumerable<T> entities);
    public Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    public Task<bool> AnyAsync();
    public Task<int> CountAsync(Expression<Func<T, bool>> filter);
    public Task<int> CountAsync();
    public Task<T> GetByIdAsync(object id);
    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
    public void Update(T entity);
    public void UpdateRange(IEnumerable<T> entities);
    public void Delete(T entity);
    public void DeleteRange(IEnumerable<T> entities);
    public Task Delete(object id);
    public int SaveChange();
    public Task SaveChangeAsync(CancellationToken token);
    
}