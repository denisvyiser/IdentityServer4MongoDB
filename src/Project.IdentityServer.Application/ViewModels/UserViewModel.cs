using Project.identityserver.Domain.ModelsValueObject;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Project.identityserver.Application.ViewModels
{
    public class UserViewModel
    {
        public virtual Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string SubjectId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        //Provider extern login
        public string ProviderName { get; set; }

        //Provider extern login id 
        public string ProviderSubjectId { get; set; }

        public int AccessFailedCount { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }
}
