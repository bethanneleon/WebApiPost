using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiPost.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleOperations = new HashSet<RoleOperation>();
            Users = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RoleOperation> RoleOperations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
