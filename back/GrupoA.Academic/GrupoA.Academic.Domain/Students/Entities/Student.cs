using GrupoA.Academic.Commom.Generals;
using GrupoA.Academic.Domain.Abstractions.Entities;
using System;

namespace GrupoA.Academic.Domain.Students.Entities;
public class Student : BaseEntity
{
    public int Code { get; set; }    
    public string Name { get; set; }
    public string Email { get; set; }
    public int RA { get; set; }
    public string CPF { get; set; }
    protected Student()
    {
    }
    public Student(Guid id, string name, string email, int ra, string cpf) : base(id)
    {
        Id = id;
        Name = name;
        Email = email;
        RA = ra;
        CPF = AcademicMethods.ExtractNumbersOnly(cpf);
    }
}