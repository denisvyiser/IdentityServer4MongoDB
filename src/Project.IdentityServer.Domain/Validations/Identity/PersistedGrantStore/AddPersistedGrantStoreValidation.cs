using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class AddPersistedGrantStoreValidation : PersistedGrantStoreValidation<AddPersistedGrantStoreCommand>
    {
        public AddPersistedGrantStoreValidation()
        {
            Validate();
        }
    }
}