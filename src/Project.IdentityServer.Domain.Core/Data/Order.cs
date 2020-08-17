using System;

namespace Project.identityserver.Domain.Core.Data
{
    public class Order
    {
        public string Property { get; set; }
        public bool Crescent { get; set; }

        public Order(string property, bool crescent)
        {
            Property = property;
            Crescent = crescent;
        }

        public Order(string property, string crescent)
            : this(property, Convert.ToBoolean(crescent)) { }
    }
}