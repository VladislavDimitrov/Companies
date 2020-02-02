using ApplicationLayer.Models.Employees;
using ApplicationLayer.Utilities.DTOs;
using AutoMapper;
using DataLayer.Entities;

namespace ApplicationLayer.AutoMapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeDto, EmployeeViewModel>().ReverseMap();
            CreateMap<CreateEmployeeViewModel, EmployeeDto>().ReverseMap();
        }
    }
}
