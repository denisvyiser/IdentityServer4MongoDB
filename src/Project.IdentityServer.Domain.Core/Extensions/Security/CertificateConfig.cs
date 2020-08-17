using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Project.identityserver.Domain.Core.Extensions.Security
{
    class CertificateConfig
    {
         public string FileDirectory { get; set; }
         public string Password { get; set; }
    }
}
