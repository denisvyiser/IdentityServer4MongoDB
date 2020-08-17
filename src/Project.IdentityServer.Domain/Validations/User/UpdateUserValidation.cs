using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UpdateUserValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            ValidateId();
            Validate();
        }
    }
}