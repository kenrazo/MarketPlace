﻿namespace MarketPlace.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
