using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UpdateDeviceCodeStoreValidation : DeviceCodeStoreValidation<UpdateDeviceCodeStoreCommand>
    {
        public UpdateDeviceCodeStoreValidation()
        {
            ValidateId();
            Validate();
        }
    }
}