using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class RemovePersistedGrantStoreCommand : PersistedGrantStoreCommand, IRemoveCommand
    {
        public RemovePersistedGrantStoreCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePersistedGrantStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}