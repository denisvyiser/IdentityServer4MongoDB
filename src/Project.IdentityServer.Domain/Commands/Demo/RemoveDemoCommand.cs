using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class RemoveDemoCommand : DemoCommand, IRemoveCommand
    {
        public RemoveDemoCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDemoValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}