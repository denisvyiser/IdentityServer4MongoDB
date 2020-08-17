using FluentValidation;
using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class ResourcesStoreValidation<T> : AbstractValidator<T> where T : ResourcesStoreCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty().WithMessage("O código é obrigatório");
        }

        protected void Validate()
        {
            RuleFor(x => x.OfflineAccess)
                .NotNull().NotEmpty().WithMessage("A informação de acesso off-line é obrigatória");
        }
    }
}