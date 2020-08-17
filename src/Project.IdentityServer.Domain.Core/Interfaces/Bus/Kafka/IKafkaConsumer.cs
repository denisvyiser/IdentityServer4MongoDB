using Project.identityserver.Domain.Core.Bus;
using System.Threading.Tasks;

namespace Project.identityserver.Domain.Core.Interfaces.Bus
{
    public interface IKafkaConsumer
    {
        Task<TResult<T>> Consume<T>(string topic);
    }
}