using AutoMapper;
using MovieBooking_DomainModels;
using MovieBooking_DTO;

namespace MovieBooking_API.Helper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Role, option => option.MapFrom(s => s.Role.RoleName));
        }
    }
}