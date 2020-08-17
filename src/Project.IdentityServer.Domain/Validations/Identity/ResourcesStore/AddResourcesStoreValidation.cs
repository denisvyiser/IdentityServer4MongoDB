using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class AddResourcesStoreValidation : ResourcesStoreValidation<AddResourcesStoreCommand>
    {
        public AddResourcesStoreValidation()
        {
            Validate();
        }
    }
}