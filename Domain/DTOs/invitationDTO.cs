namespace Domain.DTOs
{
    public class invitationDTO
    {
        public int id { get; set; }
        public bool Attended { get; set; }
        public MeetDTO Meet { get; set; }
    }
}
