using Project.identityserver.Domain.Models;

namespace Project.identityserver.Domain.Interfaces.Events
{
    public interface IDemoEvent
    {
        DemoModel Demo { get; set; }
    }
}