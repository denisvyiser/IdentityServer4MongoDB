
using Project.identityserver.Domain.Core.GenericEvents;
using Project.identityserver.Domain.Core.Models;

namespace Project.identityserver.Domain.Events
{
    public class UpdatedAllDescriptionDemoEvent : GenericEvent<BsonParams>
    {
        public UpdatedAllDescriptionDemoEvent(BsonParams _entity) : base(_entity)
        {
        }
    }
}
