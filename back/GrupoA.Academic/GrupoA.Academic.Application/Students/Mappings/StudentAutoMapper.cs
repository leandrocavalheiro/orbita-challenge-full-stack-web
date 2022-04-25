using AutoMapper;
using GrupoA.Academic.Application.Students.ViewModels;
using GrupoA.Academic.Domain.Students.Entities;

namespace GrupoA.Academic.Application.Students.Mappings;

public class StudentAutoMapper : Profile
{
    public StudentAutoMapper()
    {
        CreateMap<Student, StudentViewModel>()
            .ForMember(d => d.Active, opt => opt.MapFrom(src => src.IsActive()));
        CreateMap<Student, StudentListViewModel>()
            .ForMember(d => d.Active, opt => opt.MapFrom(src => src.IsActive()));        
    }
}