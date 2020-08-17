using System.ComponentModel.DataAnnotations;

namespace Project.identityserver.Domain.Core.Extensions
{
    public class PropertyValidationAttribute : ValidationAttribute
    {
        public PropertyValidationAttribute()
        {

        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }
    }
}
