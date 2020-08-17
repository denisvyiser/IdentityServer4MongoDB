using FluentValidation;
using Project.identityserver.Domain.Models;
using Project.identityserver.Repository.Test.FakeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.identityserver.Repository.Test.Validations
{
    public class DemoModelValidacao : AbstractValidator<FakeModels.DemoModelFake>
    {

        public DemoModelValidacao()
        {
                RuleFor(c => c.Description)
                    .NotEmpty()
                    .WithMessage("Descrição não pode ser vazia!");
           
                RuleFor(c => c.Id)
                    .NotEmpty().NotNull()
                    .WithMessage("Id Inválido");
            
        }
    }
}
