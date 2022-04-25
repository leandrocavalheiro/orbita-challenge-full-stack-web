using FluentValidation;
using GrupoA.Academic.Application.Resources;
using GrupoA.Academic.Application.Students.Commands;
using GrupoA.Academic.Commom.Generals;

namespace GrupoA.Academic.Application.Students.CommandValidators;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(p => p.Name)
            .Must(AcademicMethods.Filled)
                .WithErrorCode(nameof(Messages.RequiredField))
                .WithMessage(string.Format(Messages.RequiredField, Messages.NameField));

        RuleFor(p => p.RA)
            .Must(AcademicMethods.Filled)
                .WithErrorCode(nameof(Messages.RequiredField))
                .WithMessage(string.Format(Messages.RequiredField, Messages.RAField));

        RuleFor(p => p.CPF)
            .Must(AcademicMethods.Filled)
                .WithErrorCode(nameof(Messages.RequiredField))
                .WithMessage(string.Format(Messages.RequiredField, Messages.CPFField))
            .Must(AcademicMethods.CPFValidator)
                .WithErrorCode(nameof(Messages.InvalidField))
                .WithMessage(string.Format(Messages.InvalidField, Messages.CPFField))
                .When(p => !string.IsNullOrEmpty(p.CPF));
    }
}