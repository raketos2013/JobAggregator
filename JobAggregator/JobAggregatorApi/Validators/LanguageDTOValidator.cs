using FluentValidation;
using JobAggregator.Api.DTO;

namespace JobAggregator.Api.Validators;

public class LanguageDTOValidator : AbstractValidator<LanguageDTO>
{
    public LanguageDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(2, 50)
            .WithMessage("Name must be between 2 and 50 characters.");
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required.")
            .Length(2, 2)
            .WithMessage("Code must 2 characters.");

    }
}
