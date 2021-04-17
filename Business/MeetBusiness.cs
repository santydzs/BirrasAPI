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
        public async Task<List<MeetDTO>> test()
        {
            List<Meet> MeetsDB = await _unit.Meets.GetAllFromDate(DateTime.Now);
            List<MeetDTO> dto = _mapper.Map<List<Meet>, List<MeetDTO>>(MeetsDB);
            return dto;
        }
    }
}
