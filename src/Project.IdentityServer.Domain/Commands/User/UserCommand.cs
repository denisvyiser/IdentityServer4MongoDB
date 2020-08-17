
using Project.identityserver.Domain.Core.Commands;
using Project.identityserver.Domain.ModelsValueObject;
using System.Collections.Generic;

namespace Project.identityserver.Domain.Commands
{
    public abstract class UserCommand : Command
    {
        public string SubjectId { get; protected set; }
        public string Username { get; protected set; }
        public string Name { get; protected set; }

        public string Email { get; protected set; }
        public string Password { get; protected set; }

        //Provider extern login
        public string ProviderName { get; protected set; }

        //Provider extern login id 
        public string ProviderSubjectId { get; protected set; }

        public int AccessFailedCount { get; protected set; }
        public IEnumerable<ClaimVO> Claims { get; protected set; }
    }
}