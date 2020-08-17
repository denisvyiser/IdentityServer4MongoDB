using AutoMapper;
using Project.identityserver.Application.ViewModels;
using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Models;
using Project.identityserver.Domain.ModelsValueObject;

namespace Project.identityserver.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<DemoModel, DemoViewModel>();
            CreateMap<PagedListMongo<DemoModel>, PagedListMongo<DemoViewModel>>();

            CreateMap<User, UserViewModel>();
            CreateMap<PagedListMongo<User>, PagedListMongo<UserViewModel>>();

            CreateMap<ApiResourceStore, ApiResourceViewModel>();
            CreateMap<PagedListMongo<ApiResourceStore>, PagedListMongo<ApiResourceViewModel>>();

            CreateMap<ApiScopeStore, ApiScopeViewModel>();
            CreateMap<PagedListMongo<ApiScopeStore>, PagedListMongo<ApiScopeViewModel>>();

            CreateMap<ClientStore, ClientViewModel>();
            CreateMap<PagedListMongo<ClientStore>, PagedListMongo<ClientViewModel>>();

            CreateMap<IdentityResourceStore, IdentityResourceViewModel>();
            CreateMap<PagedListMongo<IdentityResourceStore>, PagedListMongo<IdentityResourceViewModel>>();

            CreateMap<PersistedGrantStore, PersistedGrantViewModel>();
            CreateMap<PagedListMongo<PersistedGrantStore>, PagedListMongo<PersistedGrantViewModel>>();

            CreateMap<ResourcesStore, ResourcesViewModel>();
            CreateMap<PagedListMongo<ResourcesStore>, PagedListMongo<ResourcesViewModel>>();

            CreateMap<SecretVO, SecretViewModel>();
            CreateMap<ClaimVO, ClaimViewModel>();
            CreateMap<ClientClaimVO,ClientClaimViewModel>();

            CreateMap<DeviceCodeStore, DeviceCodeViewModel>();
            CreateMap<PagedListMongo<DeviceCodeStore>, PagedListMongo<DeviceCodeViewModel>>();

        }
    }
}