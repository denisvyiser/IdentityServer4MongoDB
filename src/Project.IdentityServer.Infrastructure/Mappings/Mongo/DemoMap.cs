using MongoDB.Bson.Serialization;
using Project.identityserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Infrastructure.Mappings.Mongo
{
    public class DemoMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<DemoModel>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.Description).SetIsRequired(true);
                
            });

            //desmapear propriedade
            //map.UnmapMember(c => c.Codigo);

            //settar valor default
            //map.MapMember(c => c.Sigla).SetDefaultValue("abc");

            //Para serializar a propriedade Created, a data deve ser superior a 1/1/1900
            //map.MapMember(c => c.Created).SetShouldSerializeMethod(
            //     obj => ((Domain.Models.Local)obj).Created > new DateTime(1900, 1, 1)
            //     );

            //Serializar apenas a data
            //map.MapMember(c => c.Created).SetSerializer(new DateTimeSerializer(dateOnly: true));

            //Serializar a data no formato local
            //map.MapMember(c => c.Created).SetSerializer(new DateTimeSerializer(DateTimeKind.Local));

        }

    }
}
