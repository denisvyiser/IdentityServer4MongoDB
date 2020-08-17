using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UpdateDemoValidation : DemoValidation<UpdateDemoCommand>
    {
        public UpdateDemoValidation()
        {
            ValidateId();
            Validate();
        }
    }
}