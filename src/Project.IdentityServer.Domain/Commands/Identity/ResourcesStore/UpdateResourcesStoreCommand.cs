using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public class UpdateResourcesStoreCommand : ResourcesStoreCommand, IUpdateCommand
    {
        public UpdateResourcesStoreCommand(Guid id, bool isActive, bool offlineAccess, IEnumerable<IdentityResourceStore> identityResources, IEnumerable<ApiResourceStore> apiResources, IEnumerable<ApiScopeStore> apiScopes)
        {
            Id = id;
            IsActive = isActive;
            OfflineAccess = offlineAccess;
            IdentityResources = identityResources;
            ApiResources = apiResources;
            ApiScopes = apiScopes;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateResourcesStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}