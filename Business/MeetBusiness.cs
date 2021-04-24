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
        private IDataBusiness _dataBusiness { get; set; }
        private IMapper _mapper { get; set; }
        public MeetBusiness(IMeetUnitOfWork unit, IMapper mapper, IDataBusiness dataBusiness)
        {
            _unit = unit;
            _mapper = mapper;
            _dataBusiness = dataBusiness;
        }
        public async Task<List<invitationDTO>> GetAll(DateTime day, int userId)
        {
            List<Invitation> MeetsDB = await _unit.Invitations.GetAllFromDate(day, userId);
            var dtos = _mapper.Map<List<Invitation>, List<invitationDTO>>(MeetsDB);
            foreach(invitationDTO dto in dtos)
            {
                decimal temp = await _dataBusiness.GetTemperature(dto.Meet.City);
                dto.Meet.Temp = temp;
            }
            return dtos;
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

        public async Task<int> JoinMeet(string title, int userId)
        {
            var meetDb = await _unit.Meets.GetFromtitle(title);
            return await _unit.Invitations.Add(meetDb.Id, userId);
        }

        public async Task Assist(int invitationId)
        {
            await _unit.Invitations.Attend(invitationId);
        }
    }
}
