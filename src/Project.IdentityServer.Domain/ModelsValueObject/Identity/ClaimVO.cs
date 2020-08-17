using Project.identityserver.Domain.Core.ModelsValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Domain.ModelsValueObject
{
    public class ClaimVO : ValueObject
    {
        public ClaimVO(string type, string value)
        {
            Type = type;
            Value = value;
        }
        public string Type { get; protected set; }

        public string Value { get; protected set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Type;
            yield return Value;
            
        }

    }
}
