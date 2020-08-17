using MediatR;

namespace Project.identityserver.Domain.Core.Events
{
    public abstract class QueryMessage<TResponse> : IRequest<TResponse>
    {
        public string MessageType { get; set; }

        protected QueryMessage()
        {
            MessageType = GetType().Name;
        }
    }
}