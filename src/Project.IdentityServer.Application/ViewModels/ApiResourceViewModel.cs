using Project.identityserver.Domain.ModelsValueObject;
using System.Collections.Generic;

namespace Project.identityserver.Application.ViewModels
{
    public class ApiResourceViewModel : ResourceBaseViewModel
    {//
        // Summary:
        //     The API secret is used for the introspection endpoint. The API can authenticate
        //     with introspection using the API name and secret.
        public IEnumerable<SecretVO> ApiSecrets { get; set; }
        //
        // Summary:
        //     Models the scopes this API resource allows.
        public IEnumerable<string> Scopes { get; set; }
        //
        // Summary:
        //     Signing algorithm for access token. If empty, will use the server default signing
        //     algorithm.
        public IEnumerable<string> AllowedAccessTokenSigningAlgorithms { get; set; }
    }
}
