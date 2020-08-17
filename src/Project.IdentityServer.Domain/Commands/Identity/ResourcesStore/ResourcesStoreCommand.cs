
using Project.identityserver.Domain.Core.Commands;
using Project.identityserver.Domain.Models;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public abstract class ResourcesStoreCommand : Command
    {
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