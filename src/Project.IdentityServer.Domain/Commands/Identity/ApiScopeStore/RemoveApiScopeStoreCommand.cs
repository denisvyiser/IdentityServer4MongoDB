using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class RemoveApiScopeStoreCommand : ApiScopeStoreCommand, IRemoveCommand
    {
        public RemoveApiScopeStoreCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveApiScopeStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}