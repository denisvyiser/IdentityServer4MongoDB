using AutoMapper;
using IdentityServer4.Models;
using Project.identityserver.Domain.Commands;
using System;

namespace Project.identityserver.Application.Mappings
{
    public class ModelServiceToDomainMappingProfile : Profile
    {
        public ModelServiceToDomainMappingProfile()
        {
            CreateMap<PersistedGrant, AddPersistedGrantStoreCommand>()
                .ConstructUsing(m => new AddPersistedGrantStoreCommand(Guid.Empty, true, m.Key, m.Type, m.SubjectId, m.SessionId, m.ClientId, m.Description, m.CreationTime, m.Expiration, m.ConsumedTime, m.Data));
        }
    }
}
