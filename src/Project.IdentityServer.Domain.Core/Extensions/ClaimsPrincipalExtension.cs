using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Project.identityserver.Domain.Core.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static Guid GetUserIdFromToken(this ClaimsPrincipal claimsPrincipal)
        {
            claimsPrincipal.CheckClaimsPrincipal();

            var claims = claimsPrincipal.FindAll(t => t.Type == "sub");

            if (!claims.Any()) return Guid.Empty;

            return Guid.Parse(claims.FirstOrDefault()?.Value);
        }

        public static string GetUserNameFromToken(this ClaimsPrincipal claimsPrincipal)
        {
            claimsPrincipal.CheckClaimsPrincipal();

            var claims = claimsPrincipal.FindAll(t => t.Type == "name");

            if (!claims.Any()) return string.Empty;

            return claims.FirstOrDefault()?.Value.ToString();
        }

        public static string GetUserLoginFromToken(this ClaimsPrincipal claimsPrincipal)
        {
            claimsPrincipal.CheckClaimsPrincipal();

            var claims = claimsPrincipal.FindAll(t => t.Type == "username");

            if (!claims.Any()) return string.Empty;

            return claims.FirstOrDefault()?.Value.ToString();
        }

        public static string GetUserEmailFromToken(this ClaimsPrincipal claimsPrincipal)
        {
            claimsPrincipal.CheckClaimsPrincipal();

            var claims = claimsPrincipal.FindAll(t => t.Type == "email");

            if (!claims.Any()) return string.Empty;

            return claims.FirstOrDefault()?.Value.ToString();
        }

        public static List<string> GetUserClaimsFromToken(this ClaimsPrincipal claimsPrincipal)
        {
            claimsPrincipal.CheckClaimsPrincipal();

            var claims = claimsPrincipal.FindAll(t => t.Type == "Projectclaim");

            if (!claims.Any()) return null;

            var claimsArray = claims.FirstOrDefault()?.Value.Split(';');

            return claimsArray.ToList();
        }

        private static void CheckClaimsPrincipal(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new Exception("Usuário não autenticado. Talvez o [Authorize] não esteja definido.");
        }
    }
}