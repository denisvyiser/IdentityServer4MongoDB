using Confluent.Kafka;
using Project.identityserver.Domain.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.Core.Bus
{
    public static class KafkaProducerExtension
    {
        public static void AddKafkaProducer(
           this IServiceCollection services,
           IConfiguration configuration, string kafkaConfig)
        {
            var producerConfig = new KafkaProducerConfig();

            configuration.Bind(kafkaConfig, producerConfig);

            if (string.IsNullOrEmpty(producerConfig.BootstrapServers))
                throw new Exception("Kafka Producer Servers connection is empty.");

            services.AddScoped<IProducer<Null, string>>(s => new ProducerBuilder<Null, string>(new ProducerConfig
            {
                BootstrapServers = producerConfig.BootstrapServers,
                //SecurityProtocol = SecurityProtocol.SaslSsl,
                //SaslMechanism = SaslMechanism.ScramSha256,
                //SaslUsername = producerConfig.SaslUsername,
                //SaslPassword = producerConfig.SaslPassword,
                ClientId = producerConfig.ClientId,
                MessageTimeoutMs = Convert.ToInt32(producerConfig.MessageTimeoutMs)

            }).Build());
        }
    }
}
