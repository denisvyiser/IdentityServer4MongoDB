using System;

namespace Project.identityserver.Domain.Core.Models
{
    public class EventStore : Entity
    {
        public EventStore(string storeType, Guid userId, string userName, DateTime timeStamp, object data, Guid id)
        {
            Id = id;
            StoreType = storeType;
            UserId = userId;
            UserName = userName;
            TimeStamp = timeStamp;
            Data = data;
        }

        public string StoreType { get; protected set; }
        public Guid UserId { get; protected set; }
        public string UserName { get; protected set; }
        public DateTime TimeStamp { get; protected set; }
        public object Data { get; protected set; }
    }
}