using AutoMapper;
using Database.Entity;
using Domain.DTOs;

namespace Business.Profiles
{
    public class MeetProfiles : Profile
    {
        public MeetProfiles()
        {
            CreateMap<Meet, MeetDTO>();
        }
    }
}