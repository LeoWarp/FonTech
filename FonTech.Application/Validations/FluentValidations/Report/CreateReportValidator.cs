using FluentValidation;
using FonTech.Domain.Dto.Report;

namespace FonTech.Application.Validations.FluentValidations.Report;

public class CreateReportValidator : AbstractValidator<CreateReportDto>
{
    public CreateReportValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(1);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
    }
}