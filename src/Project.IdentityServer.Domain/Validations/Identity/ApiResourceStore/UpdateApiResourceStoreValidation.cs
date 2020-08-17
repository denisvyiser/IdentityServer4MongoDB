using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UpdateApiResourceStoreValidation : ApiResourceStoreValidation<UpdateApiResourceStoreCommand>
    {
        public UpdateApiResourceStoreValidation()
        {
            ValidateId();
            Validate();
        }
    }
}