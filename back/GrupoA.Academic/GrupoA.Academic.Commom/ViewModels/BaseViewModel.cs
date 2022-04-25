using System;

namespace GrupoA.Academic.Commom.ViewModels;

public abstract class BaseViewModel
{
    public Guid Id { get; set; }
    public bool Active { get; set; }
}