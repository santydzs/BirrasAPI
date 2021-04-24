#nullable disable

namespace Database.Entity
{
    public partial class Invitation
    {
        public int Id { get; set; }
        public bool Attended { get; set; }
        public int UserId { get; set; }
        public int MeetId { get; set; }

        public virtual Meet Meet { get; set; }
        public virtual User User { get; set; }
    }
}
