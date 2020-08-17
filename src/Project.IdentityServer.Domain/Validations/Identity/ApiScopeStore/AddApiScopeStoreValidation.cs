using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class AddApiScopeStoreValidation : ApiScopeStoreValidation<AddApiScopeStoreCommand>
    {
        public AddApiScopeStoreValidation()
        {
            Validate();
        }
    }
}