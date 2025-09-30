﻿using Prosigliere.Challenge.Domain.UnitOfWork;

namespace Prosigliere.Challenge.Infrastructure.UnitOfWork;

public class UnitOfWorkAsync(AppDbContext context) : IUnitOfWorkAsync
{
    private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<int> SaveChangesAsync(CancellationToken cancellation) => await _context.SaveChangesAsync(cancellation);

    public async ValueTask DisposeAsync() => await _context.DisposeAsync();
}
