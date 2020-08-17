using Project.identityserver.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Models
{
    public class DeviceCodeStore : Entity
    {
        public DeviceCodeStore(Guid id, bool isActive,  string deviceCode, string userCode, DateTime creationTime, int lifetime, string clientId, string description, bool isOpenId, bool isAuthorized, IEnumerable<string> requestedScopes, IEnumerable<string> authorizedScopes, string sessionId)
        {
            Id = id;
            IsActive = isActive;
            DeviceCode = deviceCode;
            UserCode = userCode;
            CreationTime = creationTime;
            Lifetime = lifetime;
            ClientId = clientId;
            Description = description;
            IsOpenId = isOpenId;
            IsAuthorized = isAuthorized;
            RequestedScopes = requestedScopes;
            AuthorizedScopes = authorizedScopes;
            SessionId = sessionId;
        }

        public string DeviceCode { get; protected set; }
		public string UserCode { get; protected set; }
		public DateTime CreationTime { get; protected set; }
		public int Lifetime { get; protected set; }
		public string ClientId { get; protected set; }
		public string Description { get; protected set; }
		public bool IsOpenId { get; protected set; }
		public bool IsAuthorized { get; protected set; }
		public IEnumerable<string> RequestedScopes { get; protected set; }
		public IEnumerable<string> AuthorizedScopes { get; protected set; }
		public string SessionId { get; protected set; }
	}
}
