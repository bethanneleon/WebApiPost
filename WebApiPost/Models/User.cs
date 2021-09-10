using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiPost.Models
{
    public partial class User
    {
        public User()
        {
            PostComments = new HashSet<PostComment>();
            Posts = new HashSet<Post>();
        }

        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
