using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPost.Models
{
	public class CreatePostViewModel: AccessViewModel
	{
		public int? IdPost { get; set; }
		public string Title { get; set; }
		public string TextContent { get; set; }

	}
}
