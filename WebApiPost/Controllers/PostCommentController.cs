using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPost.Models;

namespace WebApiPost.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostCommentController : BaseController
	{
		private readonly PostBDContext _context;

		public PostCommentController(PostBDContext context)
		{
			_context = context;
		}

		[HttpPost("AddPostComment")]
		public Response AddPostComment([FromBody] AddPostCommentViewModel comment)
		{
			Response result = new Response();

			//validar usuario
			User usuario = GetUser(comment.userName, comment.password);

			if (usuario != null)
			{
				if (usuario.IdRoleNavigation.RoleOperations.Any())
				{
					Tuple<bool, List<int>> tplCheckAuth = CheckAuthorize(usuario, (int)EnumEntity.PostComment, (int)EnumOperation.AddComment);

					if (tplCheckAuth.Item1)
					{
						if (tplCheckAuth.Item2 != null && tplCheckAuth.Item2.Any())
						{

							try
							{

									Post postSave = _context.Posts.Find(comment.IdPost);
									if (postSave != null)
									{
										if (tplCheckAuth.Item2.Contains(postSave.IdStatus))
										{
											PostComment postComment = new PostComment()
											{
												TextComment = comment.TextComment,
												IdPost = comment.IdPost,
												IdUser = usuario.IdUser

											};

											_context.PostComments.Add(postComment);
											_context.SaveChanges();

											result.result = 1;
										}
										else
										{
											result.result = 0;
											result.message = "No tiene permiso para esta acción.";
										}

									}
									else
									{
										result.result = 0;
										result.message = "Registro no encontrado.";
									}

								
							}
							catch (Exception ex)
							{
								result.result = 0;
								result.message = "Ha ocurrido un error.";
							}
						}

					}
					else
					{
						result.result = 0;
						result.message = "No tiene permiso para esta acción.";
					}
				}
				else
				{
					result.result = 0;
					result.message = "Usuario o password inválido.";
				}
			}
			else
			{
				result.result = 0;
				result.message = "Usuario o password inválido.";
			}

			return result;
		}
	}
}
