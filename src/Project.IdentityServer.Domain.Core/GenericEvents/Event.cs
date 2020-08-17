using Project.identityserver.Domain.Core.Extensions;
using MediatR;
using System;

namespace Project.identityserver.Domain.Core.Events
{
    public abstract class Event : CommandMessage, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now.ToBrazilianTimezone();
        }
    }
}