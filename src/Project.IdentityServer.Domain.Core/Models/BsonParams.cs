using System;

namespace Project.identityserver.Domain.Core.Models
{
    public class BsonParams : Entity
    {
        public string Filter { get; set; }
        public string Definition { get; set; }
        public BsonParams(string filter, string definition)
        {
            Id = Guid.NewGuid();
            Filter = filter;
            Definition = definition;
        }
    }
}
