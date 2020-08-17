using FluentValidation;
using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class DeviceCodeStoreValidation<T> : AbstractValidator<T> where T : DeviceCodeStoreCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty().WithMessage("O código é obrigatório");
        }

        protected void Validate()
        {
            RuleFor(x => x.ClientId)
                .NotNull().NotEmpty().WithMessage("O ClientID é obrigatório");
        }
    }
}