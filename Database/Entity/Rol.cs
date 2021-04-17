using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Entity
{
    public partial class Rol
    {
        public Rol()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
