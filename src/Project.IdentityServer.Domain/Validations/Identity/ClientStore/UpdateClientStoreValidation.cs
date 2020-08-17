using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UpdateClientStoreValidation : ClientStoreValidation<UpdateClientStoreCommand>
    {
        public UpdateClientStoreValidation()
        {
            ValidateId();
            Validate();
        }
    }
}