using System.Linq.Expressions;

namespace Prosigliere.Challenge.Domain.Repositories;

public interface IRepositoryAsync<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
}