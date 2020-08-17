using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class AddDemoCommand : DemoCommand, IAddCommand
    {
        public AddDemoCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddDemoValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}