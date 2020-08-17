using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class AddUserValidation : UserValidation<AddUserCommand>
    {
        public AddUserValidation()
        {
            Validate();
        }
    }
}