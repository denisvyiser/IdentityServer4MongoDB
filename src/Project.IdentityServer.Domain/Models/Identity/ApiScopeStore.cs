using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Models
{
    public class ApiScopeStore : ResourceBaseStore
    {
        public ApiScopeStore(Guid id, bool isActive, bool required, bool emphasize, bool enabled, string name, string displayName, string description, bool showInDiscoveryDocument, IEnumerable<string> userClaims, IDictionary<string, string> properties)
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

        //
        // Summary:
        //     Specifies whether the user can de-select the scope on the consent screen. Defaults
        //     to false.
        public bool Required { get; set; }
        //
        // Summary:
        //     Specifies whether the consent screen will emphasize this scope. Use this setting
        //     for sensitive or important scopes. Defaults to false.
        public bool Emphasize { get; set; }
    }
}
