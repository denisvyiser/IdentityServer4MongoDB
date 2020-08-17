using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class RemoveUserCommand : UserCommand, IRemoveCommand
    {
        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUserValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}