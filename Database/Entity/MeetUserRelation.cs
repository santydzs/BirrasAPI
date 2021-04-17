using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Entity
{
    public partial class MeetUserRelation
    {
        public int Id { get; set; }
        public int MeetId { get; set; }
        public int InvitationId { get; set; }

        public virtual Invitation Invitation { get; set; }
        public virtual Meet Meet { get; set; }
    }
}
