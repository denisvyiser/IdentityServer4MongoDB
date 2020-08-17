using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class RemoveClientStoreValidation : ClientStoreValidation<RemoveClientStoreCommand>
    {
        public RemoveClientStoreValidation()
        {
            ValidateId();
        }
    }
}