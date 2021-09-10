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
	public class BaseController : ControllerBase
	{
		public User GetUser(string userName, string password)
		{
			User usuario = null;

			using (PostBDContext db = new PostBDContext())
			{
				usuario = db.Users
					.Include(x => x.IdRoleNavigation)
					.ThenInclude(x => x.RoleOperations)
					.ThenInclude(x=>x.IdOperationNavigation)
					.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

			}

			return usuario;

		}

		public Tuple<bool, List<int>> CheckAuthorize(User user,int idEntity, int idOperation)
		{
			bool authorize = false;

			List<int> lstStatus = null;

			if (user != null && user.IdRoleNavigation.RoleOperations.Any())
			{
				if (user.IdRoleNavigation.RoleOperations.Any(x =>  x.IdOperation == idOperation && x.IdOperationNavigation.IdEntity == idEntity))
				{
					authorize = true;

					//el usuario tiene permiso
					string strStatus = user.IdRoleNavigation.RoleOperations.Where(x => x.IdOperation == idOperation && x.IdOperationNavigation.IdEntity == idEntity).FirstOrDefault().IdStatus;

					if (!string.IsNullOrEmpty(strStatus))
					{
						lstStatus = strStatus.Split(',').Select(int.Parse).ToList();
					}

				}
				else
				{
					//no tiene permiso
					authorize = false;
				}
			}

			Tuple <bool,List<int>> result = new Tuple<bool,List<int>>(authorize, lstStatus);

			return result;
		}

		public enum EnumOperation
		{
			GetAll = 1,
			Create = 2,
			Edit = 3,
			Submit = 4,
			Approve = 5,
			Reject = 6,
			AddComment = 7,
			GetPost = 9,
			GetComment = 8

		}

		public enum EnumEntity
		{
			Post = 1,
			PostComment = 2
		}

	}
}
