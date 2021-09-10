using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiPost.Models
{
    public partial class PostComment
    {
        public int IdComment { get; set; }
        public string TextComment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IdPost { get; set; }
        public int IdUser { get; set; }

        public virtual Post IdPostNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
