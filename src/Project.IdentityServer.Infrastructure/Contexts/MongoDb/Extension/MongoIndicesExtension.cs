using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.identityserver.Infrastructure.Contexts.MongoDb
{
    public static class MongoIndicesExtension
    {
        public static void IndicesConfigure(this IServiceProvider serviceCollection)
        {

            var _context = (IWriteMongoDbContext)serviceCollection.GetService(typeof(IWriteMongoDbContext));

            //MongoIndiceCreator.Create<Entity>(_context);
            MongoIndiceCreator.Create<DemoModel>(_context);
        }
    }
}
