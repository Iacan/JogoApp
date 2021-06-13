using FluentValidation;
using JogoApp.Models;

namespace JogoApp.Validator
{
    public class JogoValidator : AbstractValidator<Jogo>
    {
        public JogoValidator()
        {
            RuleFor(c => c.Titulo).Must(n => ValidateStringEmpty(n)).WithMessage("O nome não pode ser vazio.");
            RuleFor(c => c.Link).Must(n => ValidateStringEmpty(n)).WithMessage("O link não pode ser vazio.");
            RuleFor(c => c.RM).NotEmpty().WithMessage("Informe o preço").Must(RMMaiorQueZero).WithMessage("O valor deve zer maior que zero");
            RuleFor(c => c.Descricao).Must(a => ValidateStringEmpty(a)).WithMessage("A descrição não pode estar em branco.");
        }

        private static bool RMMaiorQueZero(decimal RM)
        {
            return RM > 0;
        }

        bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }
    }
}
