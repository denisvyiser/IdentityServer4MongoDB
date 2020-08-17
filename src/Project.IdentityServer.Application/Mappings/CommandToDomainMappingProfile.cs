using AutoMapper;
using Project.identityserver.Domain.Commands;
using Project.identityserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Application.Mappings
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<AddDemoCommand, DemoModel>();
            CreateMap<UpdateDemoCommand, DemoModel>();

            CreateMap<AddUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();

            CreateMap<AddApiResourceStoreCommand, ApiResourceStore>();
            CreateMap<UpdateApiResourceStoreCommand, ApiResourceStore>();

            CreateMap<AddApiScopeStoreCommand, ApiScopeStore>();
            CreateMap<UpdateApiScopeStoreCommand, ApiScopeStore>();

            CreateMap<AddClientStoreCommand, ClientStore>();
            CreateMap<UpdateClientStoreCommand, ClientStore>();

            CreateMap<AddIdentityResourceStoreCommand, IdentityResourceStore>();
            CreateMap<UpdateIdentityResourceStoreCommand, IdentityResourceStore>();

            CreateMap<AddPersistedGrantStoreCommand, PersistedGrantStore>();
            CreateMap<UpdatePersistedGrantStoreCommand, PersistedGrantStore>();

            CreateMap<AddResourcesStoreCommand, ResourcesStore>();
            CreateMap<UpdateResourcesStoreCommand, ResourcesStore>();

            CreateMap<AddDeviceCodeStoreCommand, DeviceCodeStore>();
            CreateMap<UpdateDeviceCodeStoreCommand, DeviceCodeStore>();

        }
    }
}
