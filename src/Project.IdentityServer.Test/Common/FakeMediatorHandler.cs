using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Notifications;
using Moq;
using System.Threading.Tasks;

namespace Project.identityserver.Test.Common
{
    public class FakeMediatorHandler
    {
        public Mock<IMediatorHandler> MockMediator { get; private set; }
        public DomainNotificationHandler DomainNotification { get; private set; }

        public FakeMediatorHandler()
        {
            MockMediator = new Mock<IMediatorHandler>();
            DomainNotification = new DomainNotificationHandler();
        }

        public IMediatorHandler BuilderHandler()
        {
            MockMediator.Setup(t => t.RaiseEvent(It.IsAny<DomainNotification>()))
                .Returns<DomainNotification>(t =>
                {
                    DomainNotification.GetNotifications().Add(t);
                    return Task.CompletedTask;
                });

            MockMediator.Setup(t => t.GetNotificationHandler())
                .Returns(() => DomainNotification);

            return MockMediator.Object;
        }
    }
}