using Domain.DTOs;

namespace BirrasAPI.Response
{
    public class LoginResponse
    {
        public AutResult authResult { get; set; }
        public UserDTO User { get; set; }
    }
}
