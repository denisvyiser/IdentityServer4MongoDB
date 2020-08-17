using AutoMapper;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.ModelsValueObject;

namespace Project.identityserver.Application.Mappings
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<DemoViewModel, AddDemoCommand>();
            CreateMap<DemoViewModel, UpdateDemoCommand>();
            CreateMap<DemoViewModel, RemoveDemoCommand>();

            CreateMap<UserViewModel, AddUserCommand>();
            CreateMap<UserViewModel, UpdateUserCommand>();
            CreateMap<UserViewModel, RemoveUserCommand>();

            CreateMap<ApiResourceViewModel, AddApiResourceStoreCommand>();
            CreateMap<ApiResourceViewModel, UpdateApiResourceStoreCommand>();
            CreateMap<ApiResourceViewModel, RemoveApiResourceStoreCommand>();

            CreateMap<ApiScopeViewModel, AddApiScopeStoreCommand>();
            CreateMap<ApiScopeViewModel, UpdateApiScopeStoreCommand>();
            CreateMap<ApiScopeViewModel, RemoveApiScopeStoreCommand>();

            CreateMap<ClientViewModel, AddClientStoreCommand>();
            CreateMap<ClientViewModel, UpdateClientStoreCommand>();
            CreateMap<ClientViewModel, RemoveClientStoreCommand>();

            CreateMap<IdentityResourceViewModel, AddIdentityResourceStoreCommand>();
            CreateMap<IdentityResourceViewModel, UpdateIdentityResourceStoreCommand>();
            CreateMap<IdentityResourceViewModel, RemoveIdentityResourceStoreCommand>();

            CreateMap<PersistedGrantViewModel, AddPersistedGrantStoreCommand>();
            CreateMap<PersistedGrantViewModel, UpdatePersistedGrantStoreCommand>();
            CreateMap<PersistedGrantViewModel, RemovePersistedGrantStoreCommand>();

            CreateMap<ResourcesViewModel, AddResourcesStoreCommand>();
            CreateMap<ResourcesViewModel, UpdateResourcesStoreCommand>();
            CreateMap<ResourcesViewModel, RemoveResourcesStoreCommand>();

            CreateMap<SecretViewModel, SecretVO>();
            CreateMap<ClaimViewModel, ClaimVO>();
            CreateMap<ClientClaimViewModel, ClientClaimVO>();

            CreateMap<DeviceCodeViewModel, AddDeviceCodeStoreCommand>();
            CreateMap<DeviceCodeViewModel, UpdateDeviceCodeStoreCommand>();
            CreateMap<DeviceCodeViewModel, RemoveDeviceCodeStoreCommand>();

        }
    }
}