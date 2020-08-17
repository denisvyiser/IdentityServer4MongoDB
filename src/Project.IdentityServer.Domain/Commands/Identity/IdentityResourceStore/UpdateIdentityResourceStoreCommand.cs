using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public class UpdateIdentityResourceStoreCommand : IdentityResourceStoreCommand, IUpdateCommand
    {
        public UpdateIdentityResourceStoreCommand(Guid id, bool isActive, bool enabled, string name, string displayName, string description, bool showInDiscoveryDocument, IEnumerable<string> userClaims, IDictionary<string, string> properties, bool required, bool emphasize)
        {
            Id = id;
            IsActive = isActive;
            Enabled = enabled;
            Name = name;
            DisplayName = displayName;
            Description = description;
            ShowInDiscoveryDocument = showInDiscoveryDocument;
            UserClaims = userClaims;
            Properties = properties;
            Required = required;
            Emphasize = emphasize;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateIdentityResourceStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}