using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class RemovePersistedGrantStoreValidation : PersistedGrantStoreValidation<RemovePersistedGrantStoreCommand>
    {
        public RemovePersistedGrantStoreValidation()
        {
            ValidateId();
        }
    }
}