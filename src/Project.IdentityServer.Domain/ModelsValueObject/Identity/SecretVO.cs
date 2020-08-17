using Project.identityserver.Domain.Core.ModelsValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.ModelsValueObject
{
    public class SecretVO : ValueObject
    {
        public SecretVO(string description, string value, DateTime? expiration, string type)
        {
            Description = description;
            Value = value;
            Expiration = expiration;
            Type = type;
        }

        //
        // Summary:
        //     Gets or protected sets the description.
        //
        // Value:
        //     The description.
        public string Description { get; protected set; }
        //
        // Summary:
        //     Gets or protected sets the value.
        //
        // Value:
        //     The value.
        public string Value { get; protected set; }
        //
        // Summary:
        //     Gets or protected sets the expiration.
        //
        // Value:
        //     The expiration.
        public DateTime? Expiration { get; protected set; }
        //
        // Summary:
        //     Gets or protected sets the type of the client secret.
        //
        // Value:
        //     The type of the client secret.
        public string Type { get; protected set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Description;
            yield return Value;
            yield return Expiration;
            yield return Type;
        }
    }
}
