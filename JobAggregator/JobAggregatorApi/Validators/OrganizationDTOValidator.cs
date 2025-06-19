using FluentValidation;
using JobAggregator.Api.DTO;

namespace JobAggregator.Api.Validators;

public class OrganizationDTOValidator : AbstractValidator<OrganizationDTO>
{
    public OrganizationDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(2, 50)
            .WithMessage("Name must be between 2 and 50 characters.");
        RuleFor(x => x.Website)
            .Matches("/(https:\\/\\/www\\.|http:\\/\\/www\\.|https:\\/\\/|http:\\/\\/)?" +
                    "[a-zA-Z]{2,}(\\.[a-zA-Z]{2,})(\\.[a-zA-Z]{2,})?\\/[a-zA-Z0-9]{2,}" +
                    "|((https:\\/\\/www\\.|http:\\/\\/www\\.|https:\\/\\/|http:\\/\\/)?" +
                    "[a-zA-Z]{2,}(\\.[a-zA-Z]{2,})(\\.[a-zA-Z]{2,})?)|(https:\\/\\/www\\." +
                    "|http:\\/\\/www\\.|https:\\/\\/|http:\\/\\/)?[a-zA-Z0-9]{2,}\\" +
                    ".[a-zA-Z0-9]{2,}\\.[a-zA-Z0-9]{2,}(\\.[a-zA-Z0-9]{2,})?/g")
            .WithMessage("Invalid website format.");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid Email format.");
        RuleFor(x => x.Address)
            .Length(2, 80)
            .WithMessage("Address must be between 2 and 80 characters.");
    }
}
