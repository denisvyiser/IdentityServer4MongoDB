using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class RemoveDeviceCodeStoreCommand : DeviceCodeStoreCommand, IRemoveCommand
    {
        public RemoveDeviceCodeStoreCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDeviceCodeStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}