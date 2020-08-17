using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Application.ViewModels
{
    class ClientClaimViewModel
    {
        public string Type { get; set; }
        //
        // Summary:
        //     The claim value
        public string Value { get; set; }
        //
        // Summary:
        //     The claim value type
        public string ValueType { get; set; }
    }
}
