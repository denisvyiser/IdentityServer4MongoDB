using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class RemoveResourcesStoreCommand : ResourcesStoreCommand, IRemoveCommand
    {
        public RemoveResourcesStoreCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveResourcesStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}