using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Entity
{
    public partial class User
    {
        public User()
        {
            Invitations = new HashSet<Invitation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
