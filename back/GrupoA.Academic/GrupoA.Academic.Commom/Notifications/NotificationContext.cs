using FluentValidation.Results;
using GrupoA.Academic.Commom.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GrupoA.Academic.Commom.Notifications
{
    public class NotificationContext : INotificationContext
    {

        private const int BadRequestCode = 400;
        private const int ForbiddenCode = 403;
        private const int NotFoundCode = 404;
        private const int UnauthorizedCode = 401;
        private readonly List<Notification> _notifications;
        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }
        public void BadRequest(string messageCode, string message, string field = "")
            => AddNotification(messageCode, message, BadRequestCode, field);
        public void BadRequest(ValidationResult validationResult)
            => AddNotification(validationResult);
        public void Forbidden(string messageCode, string message)
            => AddNotification(messageCode, message, ForbiddenCode, "");
        public void NotFound(string messageCode, string message)
        => AddNotification(messageCode, message, NotFoundCode, "");
        public void Unauthorized(string messageCode, string message)
            => AddNotification(messageCode, message, UnauthorizedCode, "");

        private void AddNotification(string messageCode, string message, int statusCode = 0, string field = "")
        => _notifications.Add(new Notification(field, messageCode, message, statusCode));
        private void AddNotification(ValidationResult validationResult, int statusCode = BadRequestCode)
        {
            var errors = validationResult.Errors.ToList();
            foreach (var error in errors)
                AddNotification(error.ErrorCode, error.ErrorMessage, statusCode, error.PropertyName);

        }
        public IEnumerable<Notification> GetNotifications()
            => _notifications;
        public bool HasNotifications()
            => _notifications.Any();
        public bool HasNotificationsWithNotFoundStatus()
            => _notifications.Any(p => p.Status.Equals(NotFoundCode));
    }
}
