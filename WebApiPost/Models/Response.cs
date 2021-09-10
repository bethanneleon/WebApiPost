using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPost.Models
{
	public class Response
	{
		public int result { get; set; }
		public object data { get; set; }
		public string message { get; set; }
	}
}
