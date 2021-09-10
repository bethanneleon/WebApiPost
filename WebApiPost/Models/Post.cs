using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiPost.Models
{
    public partial class Post
    {
        public Post()
        {
            PostComments = new HashSet<PostComment>();
        }

        public int IdPost { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public DateTime? PublishingDate { get; set; }
        public int IdUser { get; set; }
        public int IdStatus { get; set; }

        public virtual PostStatus IdStatusNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
    }
}
