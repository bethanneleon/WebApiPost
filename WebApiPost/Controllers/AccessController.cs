using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPost.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiPost.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccessController : BaseController
	{

		[HttpPost("Login")]
		public Response Login([FromBody] AccessViewModel credenciales)
		{
			Response result = new Response();
			try
			{
				//using (PostBDContext db = new PostBDContext())
				//{
				//	List<User> lstUsuarios = db.Users.Where(x => x.UserName == credenciales.userName && x.Password == credenciales.password).ToList();

				//	if (lstUsuarios != null && lstUsuarios.Any())
				//	{
				//		result.result = 1;
				//	}
				//	else
				//	{
				//		result.message = "Datos incorrectos.";
				//	}

					
				
				//}

				User usuario = GetUser(credenciales.userName, credenciales.password);
			}
			catch(Exception ex)
			{
				result.result = 0;
				result.message = "Ocurrió un error.";
			}

			return result;
		
		}

		

	}


}
