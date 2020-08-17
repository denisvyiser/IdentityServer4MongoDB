using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class RemoveApiScopeStoreValidation : ApiScopeStoreValidation<RemoveApiScopeStoreCommand>
    {
        public RemoveApiScopeStoreValidation()
        {
            ValidateId();
        }
    }
}