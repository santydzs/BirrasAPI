using AutoMapper;
using Database.Entity;
using Domain.DTOs;

namespace Business.Profiles
{
    public class NotificationsProfile : Profile
    {
        public NotificationsProfile()
        {
            CreateMap<Notification, NotificationDTO>();
        }
    }
}
