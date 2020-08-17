using IdentityServer4.Models;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.ModelsValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Models
{
    public class ApiResourceStore : ResourceBaseStore
    {
        public ApiResourceStore(Guid id, bool isActive, bool enabled, string name, string displayName, string description, bool showInDiscoveryDocument, IEnumerable<string> userClaims, IDictionary<string, string> properties, IEnumerable<SecretVO> apiSecrets, IEnumerable<string> scopes, IEnumerable<string> allowedAccessTokenSigningAlgorithms)
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

        //
        // Summary:
        //     The API secret is used for the introspection endpoint. The API can authenticate
        //     with introspection using the API name and secret.
        public IEnumerable<SecretVO> ApiSecrets { get; protected set; }
        //
        // Summary:
        //     Models the scopes this API resource allows.
        public IEnumerable<string> Scopes { get; protected set; }
        //
        // Summary:
        //     Signing algorithm for access token. If empty, will use the server default signing
        //     algorithm.
        public IEnumerable<string> AllowedAccessTokenSigningAlgorithms { get; protected set; }
    }
}
