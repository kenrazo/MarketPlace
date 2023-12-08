﻿using MarketPlace.Domain.Abstractions;
using MediatR;

namespace MarketPlace.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
