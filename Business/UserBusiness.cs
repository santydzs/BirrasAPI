using AutoMapper;
using Database.UnitsOfWorks.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using Database.Entity;
using Business.Interfaces;

namespace Business
{
    public class UserBusiness : IUserBusiness
    {
        private IUserUnitOfWork _unit { get; set; }
        private IMapper _mapper { get; set; }
        public UserBusiness(IUserUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var db = await _unit.Users.GetAll();
            return _mapper.Map<List<User>, List<UserDTO>>(db);
        }

        public async Task Add(UserCreateDTO dto)
        {
            await _unit.Users.Add(dto);
        }

        public async Task<UserWithPassword> GetwithPassword(string email)
        {
            var db = await _unit.Users.GetOne(email);
            return _mapper.Map<User, UserWithPassword>(db);
        }
    }
}
