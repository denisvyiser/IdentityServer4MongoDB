using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Application.ViewModels
{
  public class DeviceCodeViewModel
	{
		public Guid Id { get; set; }
		public bool IsActive { get; set; }
		public string DeviceCode { get; set; }
		public string UserCode { get; set; }
		public DateTime CreationTime { get; set; }
		public int Lifetime { get; set; }
		public string ClientId { get; set; }
		public string Description { get; set; }
		public bool IsOpenId { get; set; }
		public bool IsAuthorized { get; set; }
		public IEnumerable<string> RequestedScopes { get; set; }
		public IEnumerable<string> AuthorizedScopes { get; set; }
		public string SessionId { get; set; }
	}
}
