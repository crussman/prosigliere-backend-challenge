namespace Prosigliere.Challenge.Domain.UnitOfWork;

public interface IUnitOfWorkAsync : IAsyncDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
