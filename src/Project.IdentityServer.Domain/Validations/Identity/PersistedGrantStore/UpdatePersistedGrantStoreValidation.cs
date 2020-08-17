using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UpdatePersistedGrantStoreValidation : PersistedGrantStoreValidation<UpdatePersistedGrantStoreCommand>
    {
        public UpdatePersistedGrantStoreValidation()
        {
            ValidateId();
            Validate();
        }
    }
}