using Project.identityserver.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Models
{
    public class ResourcesStore : Entity
    {
        public ResourcesStore(Guid id, bool isActive, bool offlineAccess, IEnumerable<IdentityResourceStore> identityResources, IEnumerable<ApiResourceStore> apiResources, IEnumerable<ApiScopeStore> apiScopes)
        {
            Id = id;
            IsActive = isActive;
            OfflineAccess = offlineAccess;
            IdentityResources = identityResources;
            ApiResources = apiResources;
            ApiScopes = apiScopes;
        }

        //
        // Summary:
        //     Gets or sets a value indicating whether [offline access].
        //
        // Value:
        //     true if [offline access]; otherwise, false.
        public bool OfflineAccess { get; set; }
        //
        // Summary:
        //     Gets or sets the identity resources.
        public IEnumerable<IdentityResourceStore> IdentityResources { get; set; }
        //
        // Summary:
        //     Gets or sets the API resources.
        public IEnumerable<ApiResourceStore> ApiResources { get; set; }
        //
        // Summary:
        //     Gets or sets the API scopes.
        public IEnumerable<ApiScopeStore> ApiScopes { get; set; }
    }
}
