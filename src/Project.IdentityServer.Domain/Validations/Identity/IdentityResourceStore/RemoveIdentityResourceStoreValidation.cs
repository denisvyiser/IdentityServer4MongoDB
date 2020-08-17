using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class RemoveIdentityResourceStoreValidation : IdentityResourceStoreValidation<RemoveIdentityResourceStoreCommand>
    {
        public RemoveIdentityResourceStoreValidation()
        {
            ValidateId();
        }
    }
}