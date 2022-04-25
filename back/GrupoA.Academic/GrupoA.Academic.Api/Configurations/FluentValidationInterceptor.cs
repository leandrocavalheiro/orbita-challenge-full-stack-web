using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using GrupoA.Academic.Commom.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrupoA.Academic.Api.Configurations;

public class FluentValidationInterceptor : IValidatorInterceptor
{
    public readonly INotificationContext _notificationContext;

    public FluentValidationInterceptor(INotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }

    public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
    {
        return commonContext;
    }

    public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
    {
        if (!result.IsValid)
            _notificationContext.BadRequest(result);

        return result;
    }
}