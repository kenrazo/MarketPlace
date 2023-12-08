using MarketPlace.Domain.Abstractions;
using MediatR;

namespace MarketPlace.Application.Abstractions.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
