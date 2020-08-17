using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class AddApiResourceStoreValidation : ApiResourceStoreValidation<AddApiResourceStoreCommand>
    {
        public AddApiResourceStoreValidation()
        {
            Validate();
        }
    }
}