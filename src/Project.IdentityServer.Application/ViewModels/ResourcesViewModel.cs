using Project.identityserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Application.ViewModels
{
    public class ResourcesViewModel : ResourceBaseViewModel
    {
        public bool OfflineAccess { get; set; }
        //
        // Summary:
        //     Gets or sets the identity resources.
        public IEnumerable<IdentityResourceViewModel> IdentityResources { get; set; }
        //
        // Summary:
        //     Gets or sets the API resources.
        public IEnumerable<ApiResourceViewModel> ApiResources { get; set; }
        //
        // Summary:
        //     Gets or sets the API scopes.
        public IEnumerable<ApiScopeViewModel> ApiScopes { get; set; }
    }
}
