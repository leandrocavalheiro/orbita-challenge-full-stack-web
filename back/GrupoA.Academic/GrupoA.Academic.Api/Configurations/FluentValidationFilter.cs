using GrupoA.Academic.Commom.Interfaces;
using GrupoA.Academic.Commom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace GrupoA.Academic.Api.Configurations;
public class FluentValidationFilter : IActionFilter
{
    private readonly INotificationContext _notificationContext;

    public FluentValidationFilter(INotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (_notificationContext.HasNotifications())
        {
            var responseObj = new ErrorViewModel(_notificationContext.GetNotifications());
            if (_notificationContext.HasNotificationsWithNotFoundStatus())
            {
                context.Result = new NotFoundObjectResult(responseObj)
                {
                    ContentTypes = { "application/problem+json" }
                };
            }
            else
            {
                context.Result = new BadRequestObjectResult(responseObj)
                {
                    ContentTypes = { "application/problem+json" }
                };
            }
            return;
        }

        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.SelectMany(v => v.Errors);
            context.Result = new BadRequestObjectResult(context.ModelState.Values.SelectMany(v => v.Errors))
            {
                ContentTypes = { "application/problem+json" }
            };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (_notificationContext.HasNotifications())
        {
            var responseObj = new ErrorViewModel(_notificationContext.GetNotifications());
            if (_notificationContext.HasNotificationsWithNotFoundStatus())
            {
                context.Result = new NotFoundObjectResult(responseObj)
                {
                    ContentTypes = { "application/problem+json" }
                };
            }
            else
            {
                context.Result = new BadRequestObjectResult(responseObj)
                {
                    ContentTypes = { "application/problem+json" }
                };
            }
            return;
        }

        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState.Values.SelectMany(v => v.Errors))
            {
                ContentTypes = { "application/problem+json" }
            };
        }
    }
}