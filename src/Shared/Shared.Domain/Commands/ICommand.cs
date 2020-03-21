using MediatR;

namespace Shared.Domain.Commands
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
        public abstract void Validate();
    }
}
