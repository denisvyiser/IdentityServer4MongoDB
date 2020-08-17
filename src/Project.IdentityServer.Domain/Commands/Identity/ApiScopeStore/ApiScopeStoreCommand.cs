
using Project.identityserver.Domain.Core.Commands;

namespace Project.identityserver.Domain.Commands
{
    public abstract class ApiScopeStoreCommand : ResourceBaseStoreCommand
    {
        //
        // Summary:
        //     Specifies whether the user can de-select the scope on the consent screen. Defaults
        //     to false.
        public bool Required { get; set; }
        //
        // Summary:
        //     Specifies whether the consent screen will emphasize this scope. Use this setting
        //     for sensitive or important scopes. Defaults to false.
        public bool Emphasize { get; set; }
    }
}