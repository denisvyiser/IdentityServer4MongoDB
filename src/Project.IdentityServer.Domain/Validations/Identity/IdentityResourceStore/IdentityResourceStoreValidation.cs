using FluentValidation;
using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class IdentityResourceStoreValidation<T> : AbstractValidator<T> where T : IdentityResourceStoreCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty().WithMessage("O Id é obrigatório");
        }

        protected void Validate()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("O Name é obrigatório");
        }
    }
}