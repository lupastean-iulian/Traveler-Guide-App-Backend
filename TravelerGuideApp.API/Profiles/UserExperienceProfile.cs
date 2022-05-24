using AutoMapper;
using TravelerGuideApp.API.DTOs;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Domain.Entities;
namespace TravelerGuideApp.API.Profiles
{
    public class UserExperienceProfile : Profile
    {
        public UserExperienceProfile()
        {
            CreateMap<UserExperienceGetDto, UserExperience>()
                .ForMember(ue => ue.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(ue => ue.TravelItineraryId, opt => opt.MapFrom(s => s.TravelItineraryId))
                .ForMember(ue => ue.LocationId, opt => opt.MapFrom(s => s.LocationId))
                .ForMember(ue => ue.Priority, opt => opt.MapFrom(s => s.Priority))
                .ForMember(ue => ue.Budget, opt => opt.MapFrom(s => s.Budget))
                .ForMember(ue => ue.Description, opt => opt.MapFrom(s => s.Description)).ReverseMap();
            CreateMap<UserExperiencePutPostDto, UserExperience>()
                .ForMember(ue => ue.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(ue => ue.TravelItineraryId, opt => opt.MapFrom(s => s.TravelItineraryId))
                .ForMember(ue => ue.LocationId, opt => opt.MapFrom(s => s.LocationId))
                .ForMember(ue => ue.Priority, opt => opt.MapFrom(s => s.Priority))
                .ForMember(ue => ue.Budget, opt => opt.MapFrom(s => s.Budget))
                .ForMember(ue => ue.Description, opt => opt.MapFrom(s => s.Description)).ReverseMap();
            CreateMap<UserExperiencePutPostDto, CreateUserExperience>()
                .ForMember(ue => ue.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(ue => ue.TravelItineraryId, opt => opt.MapFrom(s => s.TravelItineraryId))
                .ForMember(ue => ue.LocationId, opt => opt.MapFrom(s => s.LocationId))
                .ForMember(ue => ue.Priority, opt => opt.MapFrom(s => s.Priority))
                .ForMember(ue => ue.Budget, opt => opt.MapFrom(s => s.Budget))
                .ForMember(ue => ue.Description, opt => opt.MapFrom(s => s.Description)).ReverseMap();
            CreateMap<CreateUserExperience, UserExperiencePutPostDto>()
                .ForMember(ue => ue.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(ue => ue.TravelItineraryId, opt => opt.MapFrom(s => s.TravelItineraryId))
                .ForMember(ue => ue.LocationId, opt => opt.MapFrom(s => s.LocationId))
                .ForMember(ue => ue.Priority, opt => opt.MapFrom(s => s.Priority))
                .ForMember(ue => ue.Budget, opt => opt.MapFrom(s => s.Budget))
                .ForMember(ue => ue.Description, opt => opt.MapFrom(s => s.Description)).ReverseMap();
        }
    }
}
