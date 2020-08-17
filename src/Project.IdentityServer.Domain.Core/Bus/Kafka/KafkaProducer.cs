using Confluent.Kafka;
using Project.identityserver.Domain.Core.Bus;
using Project.identityserver.Domain.Core.Interfaces.Bus;
using Project.identityserver.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Core.Bus
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<Null, string> _producer;

        //public KafkaProducer(IProducer<Null, string> producer)
        //{
        //    _producer = producer;
        //}

        public KafkaProducer()
        {
           
        }

        public virtual async Task Produce<T>(T message, string topic) where T : Entity
        {
            //var id = (Guid)message.GetType().GetProperty("Id").GetValue(message.Key, null)
            var id = message.Id;
            Action<DeliveryReport<Null, string>> handler = r => Callback(r, message.Id);

            try
            {
                string jsonData = JsonSerializer.Serialize(message); //JsonConvert.SerializeObject(message);
                _producer.Produce(topic, new Message<Null, string>() {Value = jsonData} , handler);
                _producer.Flush(TimeSpan.FromSeconds(1));
            }
            catch (ProduceException<Null, string> ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return;
        }
               
        private void Callback(DeliveryReport<Null, string> handler, Guid id)
        {

        }
    }
}