using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class RemoveDeviceCodeStoreValidation : DeviceCodeStoreValidation<RemoveDeviceCodeStoreCommand>
    {
        public RemoveDeviceCodeStoreValidation()
        {
            ValidateId();
        }
    }
}