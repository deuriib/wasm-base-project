using AutoMapper;
using WasmBaseProject.Domain.Dtos;
using WasmBaseProject.Domain.Models;
using WasmBaseProject.Infrastructure.Data.Models;
using WasmBaseProject.Infrastructure.ViewModels;

namespace WasmBaseProject.Adapters.Mappers;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeModel, Employee>()
            .ForCtorParam("id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("firstName", opt => opt.MapFrom(src => src.FirstName))
            .ForCtorParam("lastName", opt => opt.MapFrom(src => src.LastName))
            .ForCtorParam("email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("birthdate", opt => opt.MapFrom(src => src.Birthdate))
            .ForMember(dst => dst.Status, opt =>opt.ConvertUsing(new EmployeeStatusConverter()));

        CreateMap<Employee, EmployeeListDto>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FullName", opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Status", opt => opt.MapFrom(src => src.Status))
            .ForCtorParam("Birthdate", opt => opt.MapFrom(src => src.Birthdate));

        CreateMap<Employee, EditEmployeeDto>()
            .ForCtorParam("FirstName", opt => opt.MapFrom(src => src.FirstName))
            .ForCtorParam("LastName", opt => opt.MapFrom(src => src.LastName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Address", opt => opt.MapFrom(src => src.Address))
            .ForCtorParam("Note", opt => opt.MapFrom(src => src.Note))
            .ForCtorParam("Birthdate", opt => opt.MapFrom(src => src.Birthdate));

        CreateMap<EmployeeListDto, EmployeeListViewModel>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FullName", opt => opt.MapFrom(src => src.FullName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Status", opt => opt.MapFrom(src => src.Status))
            .ForCtorParam("Birthdate", opt => opt.MapFrom(src => $"{src.Birthdate:dd/MM/yyyy}"));
    }
}