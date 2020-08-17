using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class RemoveUserValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserValidation()
        {
            ValidateId();
        }
    }
}