using ApplicationLayer.Models.Offices;
using ApplicationLayer.Utilities.DTOs;
using AutoMapper;
using DataLayer.Entities;

namespace ApplicationLayer.AutoMapperProfiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeDto>().ReverseMap();
            CreateMap<OfficeDto, OfficeViewModel>().ReverseMap();
            CreateMap<CreateOfficeViewModel, OfficeDto>().ReverseMap();
        }
    }
}
