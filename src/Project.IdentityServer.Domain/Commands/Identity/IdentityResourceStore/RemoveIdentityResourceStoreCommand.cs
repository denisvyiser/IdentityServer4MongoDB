using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class RemoveIdentityResourceStoreCommand : IdentityResourceStoreCommand, IRemoveCommand
    {
        public RemoveIdentityResourceStoreCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveIdentityResourceStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}