using System.Linq.Expressions;

namespace HexagonalAPIWEBWORKER.Core.Domain.Interfaces.Adapters.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<TEntity?> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity?, bool>> predicate);
    }
}
