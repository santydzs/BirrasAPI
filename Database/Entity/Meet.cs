using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Entity
{
    public partial class Meet
    {
        public Meet()
        {
            Invitations = new HashSet<Invitation>();
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
