using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class RemoveDemoValidation : DemoValidation<RemoveDemoCommand>
    {
        public RemoveDemoValidation()
        {
            ValidateId();
        }
    }
}