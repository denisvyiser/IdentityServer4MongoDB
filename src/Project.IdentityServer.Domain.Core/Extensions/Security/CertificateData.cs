using System;
using System.Security.Cryptography;

namespace Project.identityserver.Domain.Core.Extensions.Security
{
    public class CertificateData
    {
        public CertificateData(RSA rSAPrivateKey, DateTime expirationDate)
        {
            RSAPrivateKey = rSAPrivateKey;
            ExpirationDate = expirationDate;
        }

        public RSA RSAPrivateKey { get; protected set; }

        public DateTime ExpirationDate { get; protected set; }
    }
}
