using Project.identityserver.Domain.Core.ModelsValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.ModelsValueObject
{
    public class ClientClaimVO : ValueObject
    {
        public ClientClaimVO(string type, string value, string valueType)
        {
            Type = type;
            Value = value;
            ValueType = valueType;
        }

        //
        // Summary:
        //     The claim type
        public string Type { get; protected set; }
        //
        // Summary:
        //     The claim value
        public string Value { get; protected set; }
        //
        // Summary:
        //     The claim value type
        public string ValueType { get; protected set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Type;
            yield return Value;
            yield return ValueType;
            
        }
    }
}
