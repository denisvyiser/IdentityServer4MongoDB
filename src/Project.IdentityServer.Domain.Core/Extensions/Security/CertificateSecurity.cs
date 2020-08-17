using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.identityserver.Domain.Core.Extensions.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Project.identityserver.Domain.Core.Extensions
{
    public static class CertificateSecurity
    {
        public static void AddCertificateSecurity(this IServiceCollection services, IConfiguration configuration, string config)
        {
            var certConfig = new CertificateConfig();
            configuration.Bind(config, certConfig);

            CertificateData certdata;

            var file = Path.Combine(AppContext.BaseDirectory, certConfig.FileDirectory);

            //using (var cert = new X509Certificate2(certConfig.Directory, certConfig.Password))
            using (var cert = new X509Certificate2(file, certConfig.Password))
            {
                certdata = new CertificateData(cert.GetRSAPrivateKey(), cert.NotAfter);
            }

            services.AddSingleton<CertificateData>();
        }
    }
}
