using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;

namespace Project.identityserver.Domain.Commands
{
    public class UpdateUserCommand : UserCommand, IUpdateCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateUserValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}