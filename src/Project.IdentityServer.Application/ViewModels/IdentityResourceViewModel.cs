using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Application.ViewModels
{
    public class IdentityResourceViewModel : ResourceBaseViewModel
    {
        //
        // Summary:
        //     Specifies whether the user can de-select the scope on the consent screen (if
        //     the consent screen wants to implement such a feature). Defaults to false.
        public bool Required { get; set; }
        //
        // Summary:
        //     Specifies whether the consent screen will emphasize this scope (if the consent
        //     screen wants to implement such a feature). Use this setting for sensitive or
        //     important scopes. Defaults to false.
        public bool Emphasize { get; set; }
    }
}
