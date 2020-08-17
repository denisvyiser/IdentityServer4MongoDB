using Project.identityserver.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Models
{
    public abstract class ResourceBaseStore : Entity
    {
        //
        // Summary:
        //     Indicates if this resource is enabled. Defaults to true.
        public bool Enabled { get; protected set; }
        //
        // Summary:
        //     The unique name of the resource.
        public string Name { get; protected set; }
        //
        // Summary:
        //     Display name of the resource.
        public string DisplayName { get; protected set; }
        //
        // Summary:
        //     Description of the resource.
        public string Description { get; protected set; }
        //
        // Summary:
        //     Specifies whether this scope is shown in the discovery document. Defaults to
        //     true.
        public bool ShowInDiscoveryDocument { get; protected set; }
        //
        // Summary:
        //     List of associated user claims that should be included when this resource is
        //     requested.
        public IEnumerable<string> UserClaims { get; protected set; }
        //
        // Summary:
        //     Gets or protected sets the custom properties for the resource.
        //
        // Value:
        //     The properties.
        public IDictionary<string, string> Properties { get; protected set; }
    }
}
