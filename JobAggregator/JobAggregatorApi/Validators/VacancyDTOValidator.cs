using FluentValidation;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Api.Validators;

public class VacancyDTOValidator : AbstractValidator<VacancyDTO>
{
    public VacancyDTOValidator(IOrganizationService organizationService)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(2, 50)
            .WithMessage("Name must be between 2 and 50 characters.");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.");
        RuleFor(x => x.Location)
            .Length(2, 50)
            .WithMessage("Location must be between 2 and 50 characters.");
        RuleFor(x => x.ScheduleType)
            .IsInEnum();
        RuleFor(x => x.OrganizationId)
            .NotEmpty()
            .WithMessage("OrganizationId is required")
            .MustAsync(async (x, cancellationToken) => { return await organizationService.GetAsync(x) != null; })
            .WithMessage("Organization does not exist");
        RuleForEach(x => x.Offers).SetValidator(new HandbookDTOValidator<Offer>());
        RuleForEach(x => x.Requirements).SetValidator(new HandbookDTOValidator<Requirement>());
        RuleForEach(x => x.Responsibilities).SetValidator(new HandbookDTOValidator<Responsibility>());
        RuleForEach(x => x.Skills).SetValidator(new HandbookDTOValidator<Skill>());
        RuleForEach(x => x.Requirements).SetValidator(new HandbookDTOValidator<Requirement>());
        RuleForEach(x => x.Specialisations).SetValidator(new HandbookDTOValidator<Specialisation>());
    }
}
