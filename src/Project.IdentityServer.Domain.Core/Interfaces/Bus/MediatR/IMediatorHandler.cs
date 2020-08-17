using Project.identityserver.Domain.Core.Commands;
using Project.identityserver.Domain.Core.Events;
using Project.identityserver.Domain.Core.Notifications;
using Project.identityserver.Domain.Core.Queries;
using MediatR;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Core.Interfaces.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task<TResponse> SendQuery<TResponse>(Query<TResponse> query) where TResponse : class;
        Task RaiseEvent<T>(T @event) where T : Event;
        bool HasNotification();
        INotificationHandler<DomainNotification> GetNotificationHandler();
    }
}