using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class RemoveResourcesStoreValidation : ResourcesStoreValidation<RemoveResourcesStoreCommand>
    {
        public RemoveResourcesStoreValidation()
        {
            ValidateId();
        }
    }
}