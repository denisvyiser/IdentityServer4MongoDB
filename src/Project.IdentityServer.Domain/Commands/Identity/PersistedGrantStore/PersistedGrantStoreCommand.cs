
using Project.identityserver.Domain.Core.Commands;
using System;

namespace Project.identityserver.Domain.Commands
{
    public abstract class PersistedGrantStoreCommand : Command
    {
        public string Key { get; protected set; }
        public string Type { get; protected set; }
        public string SubjectId { get; protected set; }
        public string SessionId { get; protected set; }
        public string ClientId { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public DateTime? Expiration { get; protected set; }
        public DateTime? ConsumedTime { get; protected set; }
        public string Data { get; protected set; }
    }
}