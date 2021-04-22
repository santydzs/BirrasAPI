using AutoMapper;
using Database.Entity;
using Domain.DTOs;

namespace Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserWithPassword>();
        }
    }
}
