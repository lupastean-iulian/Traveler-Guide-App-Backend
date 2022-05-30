using AutoMapper;
using TravelerGuideApp.API.DTOs;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.API.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityGetDto, City>()
                .ForMember(c => c.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(c => c.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(c => c.Country, opt => opt.MapFrom(s => s.Country))
                .ForMember(c => c.Locations, opt => opt.MapFrom(s => s.Locations))
                .ReverseMap();
            CreateMap<CityPutPostDto, City>()
                .ForMember(c => c.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(c => c.Country, opt => opt.MapFrom(s => s.Country))
                .ReverseMap();
            CreateMap<CityGetDto, City>()
                .ForMember(c => c.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(c => c.Country, opt => opt.MapFrom(s => s.Country))
                .ReverseMap();
            CreateMap<CityPutPostDto, UpdateCityCommand>()
                .ForMember(c => c.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(c => c.Country, opt => opt.MapFrom(s => s.Country))
                .ReverseMap();

        }
    }
}
