using IdentityModel;
using IdentityServer4;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Project.identityserver.Domain.Core.Extensions.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Project.identityserver.Domain.Core.Extensions.Identity
{
    public static class IdentityBuilderExtensions
    {        
        public static IIdentityServerBuilder AddSigningCredential(this IIdentityServerBuilder builder, IServiceCollection services, IConfiguration configuration, string config)
        {
            var certConfig = new CertificateConfig();
            configuration.Bind(config, certConfig);

            CertificateData certdata;

            var file = Path.Combine(AppContext.BaseDirectory, certConfig.FileDirectory);

            //using (var cert = new X509Certificate2(certConfig.Directory, certConfig.Password))
            var cert = new X509Certificate2(file, certConfig.Password);
            
            certdata = new CertificateData(cert.GetRSAPrivateKey(), cert.NotAfter);

            services.AddSingleton<CertificateData>(certdata);

            var signing = new RsaSecurityKey(certdata.RSAPrivateKey) {KeyId = CryptoRandom.CreateUniqueId(16, CryptoRandom.OutputFormat.Hex)};

            return builder.AddSigningCredential(
               signing,
               IdentityServerConstants.RsaSigningAlgorithm.RS256);

            
        }
    }
}
