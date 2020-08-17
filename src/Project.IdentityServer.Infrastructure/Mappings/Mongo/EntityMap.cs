using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using Project.identityserver.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Project.identityserver.Infrastructure.Mappings.Mongo
{
    public class EntityMap
    {
        public static void Configure()
        {

            BsonClassMap.RegisterClassMap<Entity>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id).SetIdGenerator(CombGuidGenerator.Instance);
                map.MapMember(c => c.IsActive).SetDefaultValue(true);
                map.MapMember(c => c.CreatedAt).SetDefaultValue(DateTime.Now.ToUniversalTime());
                
            });
        }
    }
}
