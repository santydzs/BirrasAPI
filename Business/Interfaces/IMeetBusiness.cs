using Database.Entity;
using Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMeetBusiness
    {
        Task<List<MeetDTO>> test();
    }
}
