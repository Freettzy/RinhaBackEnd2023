using Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Services.Validation;

public class ValidadorPessoa : AbstractValidator<Pessoa>
{
    private static Regex dateRegex = new Regex("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$");
    public ValidadorPessoa() {
        RuleFor(x => x.Apelido)
            .NotNull()
            .MaximumLength(32);

        RuleFor(x => x.Nome)
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.Nascimento)
            .NotNull()
            .Length(10)
            .Custom((x,_) => dateRegex.Matches(x));

        RuleFor(x => x.Stack)
            .ForEach(x => x.MaximumLength(32));
    }
}
