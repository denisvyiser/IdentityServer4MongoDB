using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UpdateIdentityResourceStoreValidation : IdentityResourceStoreValidation<UpdateIdentityResourceStoreCommand>
    {
        public UpdateIdentityResourceStoreValidation()
        {
            ValidateId();
            Validate();
        }
    }
}