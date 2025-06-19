using FluentValidation;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Api.Validators;

public class ResumeDTOValidator : AbstractValidator<ResumeDTO>
{
    public ResumeDTOValidator(IUserService userService)
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required")
            .MustAsync(async (x, cancellationToken) => { return await userService.GetAsync(x) != null; })
            .WithMessage("User does not exist");
        RuleFor(x => x.Experience)
            .Length(2, 100)
            .WithMessage("Experience must be between 2 and 100 characters.");
        RuleFor(x => x.Links)
            .Length(2, 100)
            .WithMessage("Links must be between 2 and 100 characters.");
        RuleFor(x => x.Age)
            .GreaterThan(14)
            .WithMessage("Age must be greater than 14.")
            .LessThan(100)
            .WithMessage("Age must be less than 100.");
        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required.")
            .IsInEnum();
        RuleFor(x => x.Education)
            .NotEmpty()
            .WithMessage("Education is required.")
            .Length(2, 100)
            .WithMessage("Education must be between 2 and 100 characters.");
        RuleForEach(x => x.Skills).SetValidator(new HandbookDTOValidator<Skill>());
    }
}
