using GrupoA.Academic.Commom.ViewModels;

namespace GrupoA.Academic.Application.Students.ViewModels;

public class StudentViewModel : BaseViewModel
{
    public int Code { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Ra { get; set; }
    public string Cpf { get; set; }
}