using FluentValidation.Results;
using Project.identityserver.Domain.Core.Events;
using Project.identityserver.Domain.Core.Extensions;
using System;

namespace Project.identityserver.Domain.Core.Commands
{
    public abstract class Command : CommandMessage
    {
        public Guid Id { get; protected set; }
        public DateTime Timestamp { get; private set; }
        public bool IsActive { get; protected set; }
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        protected Command()
        {
            Timestamp = DateTime.Now.ToBrazilianTimezone();
        }

        public abstract bool IsValid();
    }
}