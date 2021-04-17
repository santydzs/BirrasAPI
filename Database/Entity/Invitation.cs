using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Entity
{
    public partial class Invitation
    {
        public Invitation()
        {
            MeetUserRelations = new HashSet<MeetUserRelation>();
        }

        public int Id { get; set; }
        public bool Attended { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<MeetUserRelation> MeetUserRelations { get; set; }
    }
}
