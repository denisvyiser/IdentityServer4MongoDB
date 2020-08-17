using IdentityServer4.Models;
using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public class AddDeviceCodeStoreCommand : DeviceCodeStoreCommand, IAddCommand
    {
        public AddDeviceCodeStoreCommand(Guid id, bool isActive, string deviceCode, string userCode, DateTime creationTime, int lifetime, string clientId, string description, bool isOpenId, bool isAuthorized, IEnumerable<string> requestedScopes, IEnumerable<string> authorizedScopes, string sessionId)
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

        public override bool IsValid()
        {
            ValidationResult = new AddDeviceCodeStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}