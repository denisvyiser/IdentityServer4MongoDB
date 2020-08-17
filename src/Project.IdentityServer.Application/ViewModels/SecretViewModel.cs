using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Application.ViewModels
{
    class SecretViewModel
    {
      
        //
        // Summary:
        //     Gets or sets the description.
        //
        // Value:
        //     The description.
        public string Description { get; set; }
        //
        // Summary:
        //     Gets or sets the value.
        //
        // Value:
        //     The value.
        public string Value { get; set; }
        //
        // Summary:
        //     Gets or sets the expiration.
        //
        // Value:
        //     The expiration.
        public DateTime? Expiration { get; set; }
        //
        // Summary:
        //     Gets or sets the type of the client secret.
        //
        // Value:
        //     The type of the client secret.
        public string Type { get; set; }
    }
}
