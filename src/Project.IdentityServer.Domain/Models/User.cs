using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Domain.ModelsValueObject;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Project.identityserver.Domain.Models
{
    public class User : Entity
    {
        public User(Guid id,bool isActive ,string subjectId, string username, string name, string email, string password, string providerName, string providerSubjectId, int accessFailedCount, IEnumerable<ClaimVO> claims)
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

        public string SubjectId { get; protected set ; }
        public string Username { get; protected set ; }
        public string Name { get; protected set ; }

        public string Email { get; protected set ; }
        public string Password { get; protected set ; }

        //Provider extern login
        public string ProviderName { get; protected set ; }

        //Provider extern login id 
        public string ProviderSubjectId { get; protected set ; }
        
        public int AccessFailedCount { get; protected set; }
        public IEnumerable<ClaimVO> Claims { get; protected set ; }
        
    }
}

