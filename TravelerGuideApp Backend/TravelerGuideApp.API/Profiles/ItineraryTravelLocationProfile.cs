using AutoMapper;
using TravelerGuideApp.API.DTOs;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.API.Profiles
{
    public class ItineraryTravelLocationProfile : Profile
    {
        public ItineraryTravelLocationProfile()
        {
            CreateMap<LocationGetDto, TravelItineraryLocations>()
                .ForMember(til => til.LocationId, opt => opt.MapFrom(s => s.LocationId))
                .ReverseMap();
            CreateMap<TravelItineraryGetDto, TravelItineraryLocations>()
                .ForMember(ti => ti.TravelItineraryId, opt => opt.MapFrom(s => s.TravelId))
                .ReverseMap();
        }
    }
}
