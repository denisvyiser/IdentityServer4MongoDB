using Project.identityserver.Domain.Core.GenericEventHandlers;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.EventHandlers
{
    public class AddedDemoEventHandler : GenericEventHandler<AddedDemoEvent, DemoModel>
    {
        //IKafkaProducer _producer;
        //public AddedDemoEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user, IKafkaProducer producer) : base(eventStoreRepository, user)
        //{
        //    _producer = producer;

        //}

        public AddedDemoEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user) : base(eventStoreRepository, user)
        {
            

        }



        //public override async Task PublishEvent(DemoModel message)
        //{
          //  _producer.Produce(message,"demo-topic");
        //}

    }
}
