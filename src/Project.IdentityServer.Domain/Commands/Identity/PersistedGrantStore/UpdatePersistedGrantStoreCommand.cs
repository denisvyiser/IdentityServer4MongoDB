using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.Validations;
using System;

namespace Project.identityserver.Domain.Commands
{
    public class UpdatePersistedGrantStoreCommand : PersistedGrantStoreCommand, IUpdateCommand
    {
        public UpdatePersistedGrantStoreCommand(Guid id, bool isActive, string key, string type, string subjectId, string sessionId, string clientId, string description, DateTime creationTime, DateTime? expiration, DateTime? consumedTime, string data)
        {
            Id = id;
            IsActive = isActive;
            Key = key;
            Type = type;
            SubjectId = subjectId;
            SessionId = sessionId;
            ClientId = clientId;
            Description = description;
            CreationTime = creationTime;
            Expiration = expiration;
            ConsumedTime = consumedTime;
            Data = data;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdatePersistedGrantStoreValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}