using AutoMapper;
using Database.Entity;
using Domain.DTOs;

namespace Business.Profiles
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<Rol, RolDTO>();
        }
    }
}
