using AutoMapper;
using MovieBooking_DomainModels;
using MovieBooking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBooking_API.Helper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest=>dest.Role, option=>option.MapFrom(s=>s.Role.RoleName)); 
        }
    }
}
