using DrogaBoa.Model;
using FluentValidation;

namespace DrogaBoa.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                    .NotEmpty()
                    .MinimumLength(4)
                    .MaximumLength(255);

            RuleFor(p => p.Tipo)
                    .NotEmpty()
                    .MinimumLength(4)
                    .MaximumLength(255);
                    
            RuleFor(p => p.Preco)
                   .NotNull()
                   .GreaterThan(0)
                   .PrecisionScale(20, 2, false);
        }
    }
}