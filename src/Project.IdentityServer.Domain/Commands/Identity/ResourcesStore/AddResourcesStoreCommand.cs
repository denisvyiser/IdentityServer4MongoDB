using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public class AddResourcesStoreCommand : ResourcesStoreCommand, IAddCommand
    {
        public AddResourcesStoreCommand(Guid id, bool isActive, bool offlineAccess, IEnumerable<IdentityResourceStore> identityResources, IEnumerable<ApiResourceStore> apiResources, IEnumerable<ApiScopeStore> apiScopes)
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
            ValidationResult = new AddResourcesStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}