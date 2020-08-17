using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class RemoveClientStoreCommand : ClientStoreCommand, IRemoveCommand
    {
        public RemoveClientStoreCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}