using System;
using System.Security.Cryptography;
using System.Text;

namespace Project.identityserver.Domain.Core.Security
{
    public static class Hash
    {
        public static string GenerateHash(string text)
        {
            var hashInBytes = new SHA512Managed().ComputeHash(Encoding.ASCII.GetBytes(text));
            return Convert.ToBase64String(hashInBytes, 0, hashInBytes.Length);
        }
    }
}