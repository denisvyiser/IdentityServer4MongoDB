using Project.identityserver.Domain.Interfaces.Commands;
using Project.identityserver.Domain.ModelsValueObject;
using Project.identityserver.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public class AddUserCommand : UserCommand, IAddCommand
    {
        public AddUserCommand(Guid id, bool isActive, string subjectId, string username, string name, string email, string password, string providerName, string providerSubjectId, int accessFailedCount, IEnumerable<ClaimVO> claims)
        {
            Id = id;
            IsActive = isActive;
            SubjectId = subjectId;
            Username = username;
            Name = name;
            Email = email;
            Password = password;
            ProviderName = providerName;
            ProviderSubjectId = providerSubjectId;
            AccessFailedCount = accessFailedCount;
            Claims = claims;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddUserValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}