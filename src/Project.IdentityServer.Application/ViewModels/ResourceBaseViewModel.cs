using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Application.ViewModels
{
    public abstract class ResourceBaseViewModel
    {
        public virtual Guid Id { get; set; }

        public bool IsActive { get; set; }
        //
        // Summary:
        //     Indicates if this resource is enabled. Defaults to true.
        public bool Enabled { get; set; }
        //
        // Summary:
        //     The unique name of the resource.
        public string Name { get; set; }
        //
        // Summary:
        //     Display name of the resource.
        public string DisplayName { get; set; }
        //
        // Summary:
        //     Description of the resource.
        public string Description { get; set; }
        //
        // Summary:
        //     Specifies whether this scope is shown in the discovery document. Defaults to
        //     true.
        public bool ShowInDiscoveryDocument { get; set; }
        //
        // Summary:
        //     List of associated user claims that should be included when this resource is
        //     requested.
        public IEnumerable<string> UserClaims { get; set; }
        //
        // Summary:
        //     Gets or sets the custom properties for the resource.
        //
        // Value:
        //     The properties.
        public IDictionary<string, string> Properties { get; set; }
    }
}
