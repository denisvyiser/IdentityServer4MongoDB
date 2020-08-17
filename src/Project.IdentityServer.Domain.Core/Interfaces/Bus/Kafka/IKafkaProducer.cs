using Confluent.Kafka;
using Project.identityserver.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Core.Interfaces.Bus
{
    public interface IKafkaProducer
    {
        Task Produce<T>(T message, string topic) where T : Entity;
        
    }
}