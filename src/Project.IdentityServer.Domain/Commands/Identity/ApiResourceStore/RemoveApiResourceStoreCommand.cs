using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class RemoveApiResourceStoreCommand : ApiResourceStoreCommand, IRemoveCommand
    {
        public RemoveApiResourceStoreCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveApiResourceStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}