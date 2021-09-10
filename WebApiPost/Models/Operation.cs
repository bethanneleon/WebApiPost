using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiPost.Models
{
    public partial class Operation
    {
        public Operation()
        {
            RoleOperations = new HashSet<RoleOperation>();
        }

        public int IdOperation { get; set; }
        public string NameOperation { get; set; }
        public int IdEntity { get; set; }

        public virtual Entity IdEntityNavigation { get; set; }
        public virtual ICollection<RoleOperation> RoleOperations { get; set; }
    }
}
