using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class AddDeviceCodeStoreValidation : DeviceCodeStoreValidation<AddDeviceCodeStoreCommand>
    {
        public AddDeviceCodeStoreValidation()
        {
            Validate();
        }
    }
}