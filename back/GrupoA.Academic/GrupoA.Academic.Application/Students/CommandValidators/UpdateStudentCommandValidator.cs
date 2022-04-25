using FluentValidation;
using GrupoA.Academic.Application.Resources;
using GrupoA.Academic.Application.Students.Commands;
using GrupoA.Academic.Commom.Generals;

namespace GrupoA.Academic.Application.Students.CommandValidators;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(p => p.Name)
            .Must(AcademicMethods.Filled)
                .WithErrorCode(nameof(Messages.RequiredField))
                .WithMessage(string.Format(Messages.RequiredField, Messages.NameField));
    }
}