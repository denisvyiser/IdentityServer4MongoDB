using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class AddIdentityResourceStoreValidation : IdentityResourceStoreValidation<AddIdentityResourceStoreCommand>
    {
        public AddIdentityResourceStoreValidation()
        {
            Validate();
        }
    }
}