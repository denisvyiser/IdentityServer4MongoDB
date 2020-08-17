using AutoMapper;
using IdentityServer4.Models;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.ModelsValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Application.Mappings
{
    public class DomainToModelServiceMappingProfile : Profile
    {
        public DomainToModelServiceMappingProfile()
        {
            CreateMap<IdentityResourceStore, IdentityResource>()
                .ForMember(t => t.Required, src => src.MapFrom(f => f.Required))
                .ForMember(t => t.Emphasize, src => src.MapFrom(f => f.Emphasize))
                .ForMember(t => t.Enabled, src => src.MapFrom(f => f.Enabled))
                .ForMember(t => t.Name, src => src.MapFrom(f => f.Name))
                .ForMember(t => t.DisplayName, src => src.MapFrom(f => f.DisplayName))
                .ForMember(t => t.Description, src => src.MapFrom(f => f.Description))
                .ForMember(t => t.ShowInDiscoveryDocument, src => src.MapFrom(f => f.ShowInDiscoveryDocument))
                .ForMember(t => t.UserClaims, src => src.MapFrom(f => f.UserClaims))
                .ForMember(t => t.Properties, src => src.MapFrom(f => f.Properties));

            CreateMap<SecretVO, Secret>()
                .ForMember(t => t.Description, src => src.MapFrom(f => f.Description))
                .ForMember(t => t.Expiration, src => src.MapFrom(f => f.Expiration))
                .ForMember(t => t.Type, src => src.MapFrom(f => f.Type))
                .ForMember(t => t.Value, src => src.MapFrom(f => f.Value));

            CreateMap<ApiResourceStore, ApiResource>()
                .ForMember(t => t.ApiSecrets, src => src.MapFrom(f => f.ApiSecrets))
                .ForMember(t => t.Scopes, src => src.MapFrom(f => f.Scopes))
                .ForMember(t => t.AllowedAccessTokenSigningAlgorithms, src => src.MapFrom(f => f.AllowedAccessTokenSigningAlgorithms))
                .ForMember(t => t.Enabled, src => src.MapFrom(f => f.Enabled))
                .ForMember(t => t.Name, src => src.MapFrom(f => f.Name))
                .ForMember(t => t.DisplayName, src => src.MapFrom(f => f.DisplayName))
                .ForMember(t => t.Description, src => src.MapFrom(f => f.Description))
                .ForMember(t => t.ShowInDiscoveryDocument, src => src.MapFrom(f => f.ShowInDiscoveryDocument))
                .ForMember(t => t.UserClaims, src => src.MapFrom(f => f.UserClaims))
                .ForMember(t => t.Properties, src => src.MapFrom(f => f.Properties));

            CreateMap<ApiScopeStore, ApiScope>()
                .ForMember(t => t.Required, src => src.MapFrom(f => f.Required))
                .ForMember(t => t.Emphasize, src => src.MapFrom(f => f.Emphasize))
                .ForMember(t => t.Enabled, src => src.MapFrom(f => f.Enabled))
                .ForMember(t => t.Name, src => src.MapFrom(f => f.Name))
                .ForMember(t => t.DisplayName, src => src.MapFrom(f => f.DisplayName))
                .ForMember(t => t.Description, src => src.MapFrom(f => f.Description))
                .ForMember(t => t.ShowInDiscoveryDocument, src => src.MapFrom(f => f.ShowInDiscoveryDocument))
                .ForMember(t => t.UserClaims, src => src.MapFrom(f => f.UserClaims))
                .ForMember(t => t.Properties, src => src.MapFrom(f => f.Properties));

            CreateMap<ClientClaimVO, ClientClaim>()
                .ForMember(t => t.Type, src => src.MapFrom(f => f.Type))
                .ForMember(t => t.Value, src => src.MapFrom(f => f.Value))
                .ForMember(t => t.ValueType, src => src.MapFrom(f => f.ValueType));

            CreateMap<PersistedGrantStore, PersistedGrant>()
                .ForMember(t => t.Key, src => src.MapFrom(f => f.Key))
                .ForMember(t => t.Type, src => src.MapFrom(f => f.Type))
                .ForMember(t => t.SubjectId, src => src.MapFrom(f => f.SubjectId))
                .ForMember(t => t.SessionId, src => src.MapFrom(f => f.SessionId))
                .ForMember(t => t.ClientId, src => src.MapFrom(f => f.ClientId))
                .ForMember(t => t.Description, src => src.MapFrom(f => f.Description))
                .ForMember(t => t.CreationTime, src => src.MapFrom(f => f.CreationTime))
                .ForMember(t => t.Expiration, src => src.MapFrom(f => f.Expiration))
                .ForMember(t => t.ConsumedTime, src => src.MapFrom(f => f.ConsumedTime))
                .ForMember(t => t.Data, src => src.MapFrom(f => f.Data));


            CreateMap<ClientStore, Client>()
                .ForMember(t => t.AllowOfflineAccess, src => src.MapFrom(f => f.AllowOfflineAccess))
                .ForMember(t => t.IdentityTokenLifetime, src => src.MapFrom(f => f.IdentityTokenLifetime))
                .ForMember(t => t.AllowedIdentityTokenSigningAlgorithms, src => src.MapFrom(f => f.AllowedIdentityTokenSigningAlgorithms))
                .ForMember(t => t.AccessTokenLifetime, src => src.MapFrom(f => f.AccessTokenLifetime))
                .ForMember(t => t.AuthorizationCodeLifetime, src => src.MapFrom(f => f.AuthorizationCodeLifetime))
                .ForMember(t => t.AbsoluteRefreshTokenLifetime, src => src.MapFrom(f => f.AbsoluteRefreshTokenLifetime))
                .ForMember(t => t.SlidingRefreshTokenLifetime, src => src.MapFrom(f => f.SlidingRefreshTokenLifetime))
                .ForMember(t => t.ConsentLifetime, src => src.MapFrom(f => f.ConsentLifetime))
                .ForMember(t => t.RefreshTokenUsage, src => src.MapFrom(f => f.RefreshTokenUsage))
                .ForMember(t => t.UpdateAccessTokenClaimsOnRefresh, src => src.MapFrom(f => f.UpdateAccessTokenClaimsOnRefresh))
                .ForMember(t => t.RefreshTokenExpiration, src => src.MapFrom(f => f.RefreshTokenExpiration))
                .ForMember(t => t.AccessTokenType, src => src.MapFrom(f => f.AccessTokenType))
                .ForMember(t => t.EnableLocalLogin, src => src.MapFrom(f => f.EnableLocalLogin))
                .ForMember(t => t.IdentityProviderRestrictions, src => src.MapFrom(f => f.IdentityProviderRestrictions))
                .ForMember(t => t.IncludeJwtId, src => src.MapFrom(f => f.IncludeJwtId))
                .ForMember(t => t.Claims, src => src.MapFrom(f => f.Claims))
                .ForMember(t => t.AlwaysSendClientClaims, src => src.MapFrom(f => f.AlwaysSendClientClaims))
                .ForMember(t => t.ClientClaimsPrefix, src => src.MapFrom(f => f.ClientClaimsPrefix))
                .ForMember(t => t.PairWiseSubjectSalt, src => src.MapFrom(f => f.PairWiseSubjectSalt))
                .ForMember(t => t.UserSsoLifetime, src => src.MapFrom(f => f.UserSsoLifetime))
                .ForMember(t => t.UserCodeType, src => src.MapFrom(f => f.UserCodeType))
                .ForMember(t => t.DeviceCodeLifetime, src => src.MapFrom(f => f.DeviceCodeLifetime))
                .ForMember(t => t.AlwaysIncludeUserClaimsInIdToken, src => src.MapFrom(f => f.AlwaysIncludeUserClaimsInIdToken))
                .ForMember(t => t.AllowedScopes, src => src.MapFrom(f => f.AllowedScopes))
                .ForMember(t => t.Properties, src => src.MapFrom(f => f.Properties))
                .ForMember(t => t.BackChannelLogoutSessionRequired, src => src.MapFrom(f => f.BackChannelLogoutSessionRequired))
                .ForMember(t => t.Enabled, src => src.MapFrom(f => f.Enabled))
                .ForMember(t => t.ClientId, src => src.MapFrom(f => f.ClientId))
                .ForMember(t => t.ProtocolType, src => src.MapFrom(f => f.ProtocolType))
                .ForMember(t => t.ClientSecrets, src => src.MapFrom(f => f.ClientSecrets))
                .ForMember(t => t.RequireClientSecret, src => src.MapFrom(f => f.RequireClientSecret))
                .ForMember(t => t.ClientName, src => src.MapFrom(f => f.ClientName))
                .ForMember(t => t.Description, src => src.MapFrom(f => f.Description))
                .ForMember(t => t.ClientUri, src => src.MapFrom(f => f.ClientUri))
                .ForMember(t => t.LogoUri, src => src.MapFrom(f => f.LogoUri))
                .ForMember(t => t.RequireConsent, src => src.MapFrom(f => f.RequireConsent))
                .ForMember(t => t.AllowRememberConsent, src => src.MapFrom(f => f.AllowRememberConsent))
                .ForMember(t => t.AllowedGrantTypes, src => src.MapFrom(f => f.AllowedGrantTypes))
                .ForMember(t => t.RequirePkce, src => src.MapFrom(f => f.RequirePkce))
                .ForMember(t => t.AllowPlainTextPkce, src => src.MapFrom(f => f.AllowPlainTextPkce))
                .ForMember(t => t.RequireRequestObject, src => src.MapFrom(f => f.RequireRequestObject))
                .ForMember(t => t.AllowAccessTokensViaBrowser, src => src.MapFrom(f => f.AllowAccessTokensViaBrowser))
                .ForMember(t => t.RedirectUris, src => src.MapFrom(f => f.RedirectUris))
                .ForMember(t => t.PostLogoutRedirectUris, src => src.MapFrom(f => f.PostLogoutRedirectUris))
                .ForMember(t => t.FrontChannelLogoutUri, src => src.MapFrom(f => f.FrontChannelLogoutUri))
                .ForMember(t => t.FrontChannelLogoutSessionRequired, src => src.MapFrom(f => f.FrontChannelLogoutSessionRequired))
                .ForMember(t => t.BackChannelLogoutUri, src => src.MapFrom(f => f.BackChannelLogoutUri))
                .ForMember(t => t.AllowedCorsOrigins, src => src.MapFrom(f => f.AllowedCorsOrigins));
        }
    }
}
