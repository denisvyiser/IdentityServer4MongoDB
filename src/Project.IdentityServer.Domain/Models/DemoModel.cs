using Project.identityserver.Domain.Core.Extensions;
using Project.identityserver.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Models
{
    /// <summary>
    /// Classe modelo que ira representar a collection do MongoDb.
    /// Deve ser herdada a entidade Entity da Crosscutting, pois a mesma habilitara o uso do
    /// repositório genérico
    /// </summary>
    public class DemoModel : Entity
    {
        public DemoModel(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        [PropertyValidation]
        public string Description { get; protected set; }


       
    }
    
}