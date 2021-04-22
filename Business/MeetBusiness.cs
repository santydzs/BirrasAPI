using AutoMapper;
using Business.Interfaces;
using Database.Entity;
using Database.UnitsOfWorks.Interfaces;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class MeetBusiness : IMeetBusiness
    {
        private IMeetUnitOfWork _unit { get; set; }
        private IMapper _mapper { get; set; }
        public MeetBusiness(IMeetUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<MeetDTO>> GetAll()
        {
            List<Meet> MeetsDB = await _unit.Meets.GetAllFromDate(DateTime.Today);
            return _mapper.Map<List<Meet>, List<MeetDTO>>(MeetsDB);
        }

        public async Task AddMeetWithInvitations(MeetDTO dto, List<int> users)
        {
            using (var db = await _unit.CreateTransaction())
            {
                var idNewMeet = await _unit.Meets.Add(dto);

                foreach(int userId in users)
                {
                    await _unit.Invitations.Add(idNewMeet, userId);
                }
                await db.CommitAsync();
            }
        }

        public async Task<List<string>> GetNotifications(int meetId)
        {
            var db = await _unit.Meets.GetNotifications(meetId);
            var Notifications = new List<string>();
            db.ForEach(x => Notifications.Add(x.Text));
            return Notifications;
        }
    }
}
