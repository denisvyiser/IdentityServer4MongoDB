using FluentValidation;
using Project.identityserver.Domain.Commands;

namespace Project.identityserver.Domain.Validations
{
    public class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty().WithMessage("O código é obrigatório");
        }

        protected void Validate()
        {
            RuleFor(x => x.Username)
                .NotNull().NotEmpty().WithMessage("O UserName é obrigatório");
        }
    }
}