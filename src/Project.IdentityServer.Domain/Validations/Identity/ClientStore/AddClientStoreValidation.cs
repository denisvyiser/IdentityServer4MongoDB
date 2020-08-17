using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class AddClientStoreValidation : ClientStoreValidation<AddClientStoreCommand>
    {
        public AddClientStoreValidation()
        {
            Validate();
        }
    }
}