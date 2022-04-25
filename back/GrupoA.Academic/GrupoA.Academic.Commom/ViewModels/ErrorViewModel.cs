using GrupoA.Academic.Commom.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace GrupoA.Academic.Commom.ViewModels;

public class ErrorViewModel
{
    public Notification[] Error { get; set; }

    public ErrorViewModel(IEnumerable<Notification> errors)
    {
        Error = errors.ToArray();
    }

    public ErrorViewModel(Notification errors)
    {
        Error = new[] { errors };
    }
}