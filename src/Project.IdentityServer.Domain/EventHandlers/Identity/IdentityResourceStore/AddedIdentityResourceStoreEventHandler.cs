using Project.identityserver.Domain.Core.GenericEventHandlers;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.EventHandlers.Identity
{
    public class AddedIdentityResourceStoreEventHandler : GenericEventHandler<AddedIdentityResourceStoreEvent, IdentityResourceStore>
    {
        //IKafkaProducer _producer;
        //public AddedIdentityResourceStoreEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user, IKafkaProducer producer) : base(eventStoreRepository, user)
        //{
        //    _producer = producer;

        //}

        public AddedIdentityResourceStoreEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user) : base(eventStoreRepository, user)
        {
            

        }



      //  public override async Task PublishEvent(IdentityResourceStore message)
     //   {
          //  _producer.Produce(message,"IdentityResourceStore-topic");
      //  }

    }
}
