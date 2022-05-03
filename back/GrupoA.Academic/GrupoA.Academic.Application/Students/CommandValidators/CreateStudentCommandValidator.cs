using FluentValidation;
using GrupoA.Academic.Application.Resources;
using GrupoA.Academic.Application.Students.Commands;
using GrupoA.Academic.Commom.Generals;

namespace GrupoA.Academic.Application.Students.CommandValidators;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(p => p.Ra)
            .Must(AcademicMethods.Filled)
                .WithErrorCode(nameof(Messages.RequiredField))
                .WithMessage(string.Format(Messages.RequiredField, Messages.RaField));

        RuleFor(p => p.Cpf)
            .Must(AcademicMethods.Filled)
                .WithErrorCode(nameof(Messages.RequiredField))
                .WithMessage(string.Format(Messages.RequiredField, Messages.CpfField))
            .Must(AcademicMethods.CpfValidator)
                .WithErrorCode(nameof(Messages.InvalidField))
                .WithMessage(string.Format(Messages.InvalidField, Messages.CpfField))
                .When(p => !string.IsNullOrEmpty(p.Cpf));

        RuleFor(p => p.Name)
            .Must(AcademicMethods.Filled)
                .WithErrorCode(nameof(Messages.RequiredField))
                .WithMessage(string.Format(Messages.RequiredField, Messages.NameField));

        RuleFor(p => p.Email)
            .Must(AcademicMethods.EmailValidator)
                .WithErrorCode(nameof(Messages.InvalidField))
                .WithMessage(string.Format(Messages.InvalidField, Messages.EmailField))
                .When(p => !string.IsNullOrEmpty(p.Email));
    }
}