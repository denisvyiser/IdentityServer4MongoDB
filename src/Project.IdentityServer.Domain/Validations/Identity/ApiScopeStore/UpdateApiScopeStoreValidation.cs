using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UpdateApiScopeStoreValidation : ApiScopeStoreValidation<UpdateApiScopeStoreCommand>
    {
        public UpdateApiScopeStoreValidation()
        {
            ValidateId();
            Validate();
        }
    }
}