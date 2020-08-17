
using IdentityServer4.Models;
using Project.identityserver.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public abstract class DeviceCodeStoreCommand : Command
    {
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