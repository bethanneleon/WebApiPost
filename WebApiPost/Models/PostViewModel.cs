using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPost.Models
{
	public class PostViewModel
	{
        public int IdPost { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public DateTime? PublishingDate { get; set; }
        public int IdUser { get; set; }
		public string Writer { get; set; }
		public int IdStatus { get; set; }
		public string Status { get; set; }

		public IEnumerable<PostCommentViewModel> Comments { get; set; }

	}
	
}
