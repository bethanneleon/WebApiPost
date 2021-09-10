using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiPost.Models
{
    public partial class PostStatus
    {
        public PostStatus()
        {
            Posts = new HashSet<Post>();
        }

        public int IdStatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
