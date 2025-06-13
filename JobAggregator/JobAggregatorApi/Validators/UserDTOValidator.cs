using FluentValidation;
using JobAggregator.Api.DTO;

namespace JobAggregator.Api.Validators;

public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(2, 50)
            .WithMessage("Name must be between 2 and 50 characters.")
            .Must(z => !z.Any(char.IsDigit))
            .WithMessage("Name should not contains numbers.");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("last Name is required.")
            .Length(2, 50)
            .WithMessage("Last Name must be between 2 and 50 characters.")
            .Must(z => !z.Any(char.IsDigit))
            .WithMessage("Last Name should not contains numbers.");
        RuleFor(x => x.Login)
            .NotEmpty()
            .WithMessage("Login is required.")
            .Length(5, 20)
            .WithMessage("Login must be between 5 and 20 characters.");
        RuleFor(x => x.Login)
            .NotEmpty()
            .WithMessage("Password is required.")
            .Length(8, 20)
            .WithMessage("Password must be between 8 and 20 characters.");
    }
}
