using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class AddDemoValidation : DemoValidation<AddDemoCommand>
    {
        public AddDemoValidation()
        {
            Validate();
        }
    }
}