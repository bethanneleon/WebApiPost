using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPost.Models
{
	public class AddPostCommentViewModel : AccessViewModel
	{
		public int IdPost { get; set; }
		public string TextComment { get; set; }

	}
	public class PostCommentViewModel
	{
		public int IdComment { get; set; }
		public string TextComment { get; set; }
		public DateTime CreatedDate { get; set; }
		public int IdPost { get; set; }
		public int IdUser { get; set; }
		public string UserName { get; set; }
	}

}
