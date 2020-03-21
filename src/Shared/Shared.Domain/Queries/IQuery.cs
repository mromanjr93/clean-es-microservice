using MediatR;

namespace Shared.Domain.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
