using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.ModelsValueObject;
using Project.identityserver.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public class UpdateApiResourceStoreCommand : ApiResourceStoreCommand, IUpdateCommand
    {
        public UpdateApiResourceStoreCommand(Guid id, bool isActive, bool enabled, string name, string displayName, string description, bool showInDiscoveryDocument, IEnumerable<string> userClaims, IDictionary<string, string> properties, IEnumerable<SecretVO> apiSecrets, IEnumerable<string> scopes, IEnumerable<string> allowedAccessTokenSigningAlgorithms)
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
            ApiSecrets = apiSecrets;
            Scopes = scopes;
            AllowedAccessTokenSigningAlgorithms = allowedAccessTokenSigningAlgorithms;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateApiResourceStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}