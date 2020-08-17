using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Infrastructure.Mappings.Mongo
{
    public class MongoDbPersistenceConfigure
    {
        public static void Configure()
        {

            EntityMap.Configure();
            DemoMap.Configure();

            
        }
    }
}
