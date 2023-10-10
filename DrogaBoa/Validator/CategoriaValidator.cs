using DrogaBoa.Model;
using FluentValidation;

namespace DrogaBoa.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {   
            RuleFor(c => c.Tipo)
                    .NotEmpty()
                    .MinimumLength(4)
                    .MaximumLength(255);
        }
    }
}