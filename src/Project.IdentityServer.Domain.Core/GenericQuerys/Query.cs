using FluentValidation.Results;
using Project.identityserver.Domain.Core.Events;
using Project.identityserver.Domain.Core.Extensions;
using System;

namespace Project.identityserver.Domain.Core.Queries
{
    public abstract class Query<TResponse> : QueryMessage<TResponse>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        protected Query()
        {
            Timestamp = DateTime.Now.ToBrazilianTimezone();
        }

        public abstract bool IsValid();
    }
}