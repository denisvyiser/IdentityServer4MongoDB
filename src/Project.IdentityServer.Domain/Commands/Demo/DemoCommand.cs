
using Project.identityserver.Domain.Core.Commands;

namespace Project.identityserver.Domain.Commands
{
    public abstract class DemoCommand : Command
    {
        public string Description { get; protected set; }
    }
}