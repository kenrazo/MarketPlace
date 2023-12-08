using MarketPlace.Domain.Abstractions;
using MediatR;

namespace MarketPlace.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {
    }

    public interface IBaseCommand
    {
    }
}
