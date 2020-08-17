
using Project.identityserver.Domain.Core.Commands;

namespace Project.identityserver.Domain.Commands
{
    public abstract class IdentityResourceStoreCommand : ResourceBaseStoreCommand
    {
        //
        // Summary:
        //     Specifies whether the user can de-select the scope on the consent screen (if
        //     the consent screen wants to implement such a feature). Defaults to false.
        public bool Required { get; protected set; }
        //
        // Summary:
        //     Specifies whether the consent screen will emphasize this scope (if the consent
        //     screen wants to implement such a feature). Use this protected setting for sensitive or
        //     important scopes. Defaults to false.
        public bool Emphasize { get; protected set; }
    }
}