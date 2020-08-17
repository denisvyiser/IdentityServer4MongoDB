using Project.identityserver.Domain.Core.GenericEventHandlers;
using Project.identityserver.Domain.Core.Interfaces;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Events;
using Project.identityserver.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.EventHandlers.Identity
{
    public class AddedApiScopeStoreEventHandler : GenericEventHandler<AddedApiScopeStoreEvent, ApiScopeStore>
    {
        //IKafkaProducer _producer;
        //public AddedApiScopeStoreEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user, IKafkaProducer producer) : base(eventStoreRepository, user)
        //{
        //    _producer = producer;

        //}

        public AddedApiScopeStoreEventHandler(IEventStoreRepository eventStoreRepository, ClaimsPrincipal user) : base(eventStoreRepository, user)
        {
            

        }



       // public override async Task PublishEvent(ApiScopeStore message)
       // {
          //  _producer.Produce(message,"ApiScopeStore-topic");
      //  }

    }
}
