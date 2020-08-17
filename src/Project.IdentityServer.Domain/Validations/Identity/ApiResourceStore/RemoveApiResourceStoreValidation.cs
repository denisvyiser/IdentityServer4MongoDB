using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class RemoveApiResourceStoreValidation : ApiResourceStoreValidation<RemoveApiResourceStoreCommand>
    {
        public RemoveApiResourceStoreValidation()
        {
            ValidateId();
        }
    }
}