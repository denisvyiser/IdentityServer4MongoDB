using Project.identityserver.Domain.Core.GenericCommand;
using Project.identityserver.Domain.Models;
using MongoDB.Driver;

namespace Project.identityserver.Domain.Commands
{
    public class UpdateAllDescriptionCommand : UpdateManyGenericCommand<DemoModel>
    {
        public UpdateAllDescriptionCommand(FilterDefinition<DemoModel> filter, UpdateDefinition<DemoModel> updateDefinition) : base(filter, updateDefinition)
        {
            _filter = filter;
            _updateDefinition = updateDefinition;

        }
    }
}
