using FluentValidation;
using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class ClientStoreValidation<T> : AbstractValidator<T> where T : ClientStoreCommand
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