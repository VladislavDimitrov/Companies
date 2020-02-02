using ApplicationLayer.Models.Companies;
using ApplicationLayer.Utilities.DTOs;
using AutoMapper;
using DataLayer.Entities;

namespace ApplicationLayer.AutoMapperProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyDto, CompanyViewModel>().ReverseMap();
        }
    }
}
