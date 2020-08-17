using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;

namespace Project.identityserver.Domain.Commands
{
    public class UpdateDemoCommand : DemoCommand, IUpdateCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateDemoValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}