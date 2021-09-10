using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiPost.Models
{
    public partial class Entity
    {
        public Entity()
        {
            Operations = new HashSet<Operation>();
        }

        public int IdEntity { get; set; }
        public string NameEntity { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
