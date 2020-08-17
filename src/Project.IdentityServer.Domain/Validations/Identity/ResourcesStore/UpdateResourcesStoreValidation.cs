using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UpdateResourcesStoreValidation : ResourcesStoreValidation<UpdateResourcesStoreCommand>
    {
        public UpdateResourcesStoreValidation()
        {
            ValidateId();
            Validate();
        }
    }
}