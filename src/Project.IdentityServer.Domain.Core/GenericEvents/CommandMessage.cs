using MediatR;

namespace Project.identityserver.Domain.Core.Events
{
    public abstract class CommandMessage : IRequest
    {
        public string MessageType { get; protected set; }

        protected CommandMessage()
        {
            MessageType = GetType().Name;
        }
    }
}