using IdentityServer4.Models;
using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public class UpdateClientStoreCommand : ClientStoreCommand, IUpdateCommand
    {
        public UpdateClientStoreCommand(Guid id, bool isActive, bool allowOfflineAccess, int identityTokenLifetime, IEnumerable<string> allowedIdentityTokenSigningAlgorithms, int accessTokenLifetime, int authorizationCodeLifetime, int absoluteRefreshTokenLifetime, int slidingRefreshTokenLifetime, int? consentLifetime, TokenUsage refreshTokenUsage, bool updateAccessTokenClaimsOnRefresh, TokenExpiration refreshTokenExpiration, AccessTokenType accessTokenType, bool enableLocalLogin, IEnumerable<string> identityProviderRestrictions, bool includeJwtId, IEnumerable<ClientClaim> claims, bool alwaysSendClientClaims, string clientClaimsPrefix, string pairWiseSubjectSalt, int? userSsoLifetime, string userCodeType, int deviceCodeLifetime, bool alwaysIncludeUserClaimsInIdToken, IEnumerable<string> allowedScopes, IDictionary<string, string> properties, bool backChannelLogoutSessionRequired, bool enabled, string clientId, string protocolType, IEnumerable<Secret> clientSecrets, bool requireClientSecret, string clientName, string description, string clientUri, string logoUri, bool requireConsent, bool allowRememberConsent, IEnumerable<string> allowedGrantTypes, bool requirePkce, bool allowPlainTextPkce, bool requireRequestObject, bool allowAccessTokensViaBrowser, IEnumerable<string> redirectUris, IEnumerable<string> postLogoutRedirectUris, string frontChannelLogoutUri, bool frontChannelLogoutSessionRequired, string backChannelLogoutUri, IEnumerable<string> allowedCorsOrigins)
        {
            Id = id;
            IsActive = isActive;
            AllowOfflineAccess = allowOfflineAccess;
            IdentityTokenLifetime = identityTokenLifetime;
            AllowedIdentityTokenSigningAlgorithms = allowedIdentityTokenSigningAlgorithms;
            AccessTokenLifetime = accessTokenLifetime;
            AuthorizationCodeLifetime = authorizationCodeLifetime;
            AbsoluteRefreshTokenLifetime = absoluteRefreshTokenLifetime;
            SlidingRefreshTokenLifetime = slidingRefreshTokenLifetime;
            ConsentLifetime = consentLifetime;
            RefreshTokenUsage = refreshTokenUsage;
            UpdateAccessTokenClaimsOnRefresh = updateAccessTokenClaimsOnRefresh;
            RefreshTokenExpiration = refreshTokenExpiration;
            AccessTokenType = accessTokenType;
            EnableLocalLogin = enableLocalLogin;
            IdentityProviderRestrictions = identityProviderRestrictions;
            IncludeJwtId = includeJwtId;
            Claims = claims;
            AlwaysSendClientClaims = alwaysSendClientClaims;
            ClientClaimsPrefix = clientClaimsPrefix;
            PairWiseSubjectSalt = pairWiseSubjectSalt;
            UserSsoLifetime = userSsoLifetime;
            UserCodeType = userCodeType;
            DeviceCodeLifetime = deviceCodeLifetime;
            AlwaysIncludeUserClaimsInIdToken = alwaysIncludeUserClaimsInIdToken;
            AllowedScopes = allowedScopes;
            Properties = properties;
            BackChannelLogoutSessionRequired = backChannelLogoutSessionRequired;
            Enabled = enabled;
            ClientId = clientId;
            ProtocolType = protocolType;
            ClientSecrets = clientSecrets;
            RequireClientSecret = requireClientSecret;
            ClientName = clientName;
            Description = description;
            ClientUri = clientUri;
            LogoUri = logoUri;
            RequireConsent = requireConsent;
            AllowRememberConsent = allowRememberConsent;
            AllowedGrantTypes = allowedGrantTypes;
            RequirePkce = requirePkce;
            AllowPlainTextPkce = allowPlainTextPkce;
            RequireRequestObject = requireRequestObject;
            AllowAccessTokensViaBrowser = allowAccessTokensViaBrowser;
            RedirectUris = redirectUris;
            PostLogoutRedirectUris = postLogoutRedirectUris;
            FrontChannelLogoutUri = frontChannelLogoutUri;
            FrontChannelLogoutSessionRequired = frontChannelLogoutSessionRequired;
            BackChannelLogoutUri = backChannelLogoutUri;
            AllowedCorsOrigins = allowedCorsOrigins;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateClientStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}