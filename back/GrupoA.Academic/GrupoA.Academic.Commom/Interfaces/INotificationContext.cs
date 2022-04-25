using FluentValidation.Results;
using GrupoA.Academic.Commom.Notifications;
using System.Collections.Generic;

namespace GrupoA.Academic.Commom.Interfaces;

public interface INotificationContext
{
    void BadRequest(string messageCode, string message, string field = "");
    void BadRequest(ValidationResult validationResult);
    void Forbidden(string messageCode, string message);
    void NotFound(string messageCode, string message);
    void Unauthorized(string messageCode, string message);
    IEnumerable<Notification> GetNotifications();
    bool HasNotifications();
    public bool HasNotificationsWithNotFoundStatus();
}