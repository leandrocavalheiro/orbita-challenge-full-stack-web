using System;

namespace GrupoA.Academic.Commom.ViewModels;

public abstract class ListBaseViewModel
{
    public Guid Id { get; set; }
    public bool Active { get; set; }
}