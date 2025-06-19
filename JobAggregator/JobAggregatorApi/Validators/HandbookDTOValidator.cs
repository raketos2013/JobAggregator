using FluentValidation;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Interfaces;

namespace JobAggregator.Api.Validators;

public class HandbookDTOValidator : AbstractValidator<HandbookDTO>
{
    public HandbookDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(2, 50)
            .WithMessage("Name must be between 2 and 50 characters.");
    }
}
