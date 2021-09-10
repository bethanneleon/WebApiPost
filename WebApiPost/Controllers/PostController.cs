using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPost.Models;

namespace WebApiPost.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class PostController : BaseController

	{
		private readonly PostBDContext _context;

		public PostController(PostBDContext context)
		{
			_context = context;
		}

		[HttpGet]
		public Response Get(AccessViewModel credenciales)
		{
			List<PostViewModel> lstPost = null;

			Response result = new Response();

			//validar usuario
			User usuario = GetUser(credenciales.userName, credenciales.password);

			if (usuario != null)
			{
				if (usuario.IdRoleNavigation.RoleOperations.Any())
				{
					Tuple<bool, List<int>> tplCheckAuth = CheckAuthorize(usuario, (int)EnumEntity.Post, (int)EnumOperation.GetAll);

					if (tplCheckAuth.Item1)
					{
							if (tplCheckAuth.Item2 != null && tplCheckAuth.Item2.Any())
							{
								lstPost = _context.Posts
								.Include(x => x.IdUserNavigation)
								.Include(x => x.IdStatusNavigation)
								.Where(x => tplCheckAuth.Item2.Contains(x.IdStatus)).Select(x => new PostViewModel
								{
									IdPost = x.IdPost,
									IdStatus = x.IdStatus,
									IdUser = x.IdUser,
									PublishingDate = x.PublishingDate,
									Status = x.IdStatusNavigation.Name,
									TextContent = x.TextContent,
									Title = x.Title,
									Writer = x.IdUserNavigation.UserName

								}).ToList();

							}

							result.result = 1;
							result.data = lstPost;
						

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

		[HttpGet("{id}")]
		public Response Get([FromBody] AccessViewModel credenciales, int id)
		{
			PostViewModel post = null;

			Response result = new Response();

			//validar usuario
			User usuario = GetUser(credenciales.userName, credenciales.password);

			if (usuario != null)
			{
				if (usuario.IdRoleNavigation.RoleOperations.Any())
				{
					Tuple<bool, List<int>> tplCheckAuth = CheckAuthorize(usuario, (int)EnumEntity.Post, (int)EnumOperation.GetPost);

					if (tplCheckAuth.Item1)
					{

						post = _context.Posts
							.Include(x => x.IdUserNavigation)
							.Include(x => x.IdStatusNavigation)
							.Include(x => x.PostComments)
							.ThenInclude(y => y.IdUserNavigation)
							.Where(x => x.IdPost == id && x.IdUser == usuario.IdUser).Select(x => new PostViewModel
							{
								IdPost = x.IdPost,
								IdStatus = x.IdStatus,
								IdUser = x.IdUser,
								PublishingDate = x.PublishingDate,
								Status = x.IdStatusNavigation.Name,
								TextContent = x.TextContent,
								Title = x.Title,
								Writer = x.IdUserNavigation.UserName,
								Comments = x.PostComments.Select(o => new PostCommentViewModel
								{
									CreatedDate = o.CreatedDate,
									IdComment = o.IdComment,
									IdPost = o.IdPost,
									IdUser = o.IdUser,
									TextComment = o.TextComment,
									UserName = o.IdUserNavigation.UserName
								})
							}).First();

						if (post != null)
						{

							if (tplCheckAuth.Item2 != null && tplCheckAuth.Item2.Any())
							{
								if (tplCheckAuth.Item2.Contains(post.IdStatus))
								{
									result.result = 1;
									result.data = post;
								}
								else
								{
									result.result = 0;
									result.message = "No tiene permiso para esta acción.";
								}
							}
							else
							{
								result.result = 1;
								result.data = post;
							}

						}
						else
						{
							result.result = 0;
							result.message = "Registro no encontrado.";
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

		[HttpPost("AddPost")]
		public Response AddPost([FromBody] CreatePostViewModel post)
		{
			Response result = new Response();

			//validar usuario
			User usuario = GetUser(post.userName, post.password);

			if (usuario != null)
			{
				if (usuario.IdRoleNavigation.RoleOperations.Any())
				{
					Tuple<bool, List<int>> tplCheckAuth = CheckAuthorize(usuario, (int)EnumEntity.Post, (int)EnumOperation.Create);

					if (tplCheckAuth.Item1)
					{
						try
						{

							Post postSave = new Post
							{
								Title = post.Title,
								TextContent = post.TextContent,
								IdStatus = 1,
								IdUser = usuario.IdUser,

							};

							_context.Posts.Add(postSave);
							_context.SaveChanges();

							result.result = 1;


						}
						catch (Exception ex)
						{
							result.result = 0;
							result.message = "Ha ocurrido un error.";
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

		[HttpPut("EditPost/{id}")]
		public Response EditPost([FromBody] CreatePostViewModel post, int id)
		{

			Response result = new Response();

			if (id != post.IdPost)
			{
				result.result = 0;
				result.message = "Error en request.";
			}

			//validar usuario
			User usuario = GetUser(post.userName, post.password);

			if (usuario != null)
			{
				if (usuario.IdRoleNavigation.RoleOperations.Any())
				{
					Tuple<bool, List<int>> tplCheckAuth = CheckAuthorize(usuario, (int)EnumEntity.Post, (int)EnumOperation.Edit);

					if (tplCheckAuth.Item1)
					{
						if (tplCheckAuth.Item2 != null && tplCheckAuth.Item2.Any())
						{
							try
							{

								Post postSave = _context.Posts.Find(id);
								if (postSave != null)
								{
									if (postSave.IdUser == usuario.IdUser)
									{
										if (tplCheckAuth.Item2.Contains(postSave.IdStatus))
										{
											postSave.Title = post.Title;
											postSave.TextContent = post.TextContent;

											_context.Entry(postSave).State = EntityState.Modified;
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
						else
						{
							result.result = 0;
							result.message = "No tiene permiso para esta acción.";
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

		[HttpPost("SubmitPost/{id}")]
		public Response SubmitPost([FromBody] AccessViewModel credenciales, int id)
		{
			Response result = new Response();

			//validar usuario
			User usuario = GetUser(credenciales.userName, credenciales.password);

			if (usuario != null)
			{
				if (usuario.IdRoleNavigation.RoleOperations.Any())
				{
					Tuple<bool, List<int>> tplCheckAuth = CheckAuthorize(usuario, (int)EnumEntity.Post, (int)EnumOperation.Submit);

					if (tplCheckAuth.Item1)
					{
						if (tplCheckAuth.Item2 != null && tplCheckAuth.Item2.Any())
						{
							try
							{

									Post postSave = _context.Posts.Find(id);
									if (postSave != null)
									{
										if (postSave.IdUser == usuario.IdUser)
										{
											string messageResult = EditStatusPost(postSave, _context, tplCheckAuth.Item2, 2, (int)EnumOperation.Submit);
											if (messageResult == "")
											{
												result.result = 1;
											}
											else
											{
												result.result = 0;
												result.message = messageResult;
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
										result.message = "Registro no encontrado.";
									}

								
							}
							catch (Exception ex)
							{
								result.result = 0;
								result.message = "Ha ocurrido un error.";
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
		[HttpPost("ApprovePost/{id}")]
		public Response ApprovePost([FromBody] AccessViewModel credenciales, int id)
		{
			Response result = new Response();

			//validar usuario
			User usuario = GetUser(credenciales.userName, credenciales.password);

			if (usuario != null)
			{
				if (usuario.IdRoleNavigation.RoleOperations.Any())
				{
					Tuple<bool, List<int>> tplCheckAuth = CheckAuthorize(usuario, (int)EnumEntity.Post, (int)EnumOperation.Approve);

					if (tplCheckAuth.Item1)
					{
						if (tplCheckAuth.Item2 != null && tplCheckAuth.Item2.Any())
						{
							try
							{
									Post postSave = _context.Posts.Find(id);
									if (postSave != null)
									{
										string messageResult = EditStatusPost(postSave, _context, tplCheckAuth.Item2, 5, (int)EnumOperation.Approve);
										if (messageResult == "")
										{
											result.result = 1;
										}
										else
										{
											result.result = 0;
											result.message = messageResult;
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
						else
						{
							result.result = 0;
							result.message = "No tiene permiso para esta acción.";
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
		[HttpPost("RejectPost/{id}")]
		public Response RejectPost([FromBody] AddPostCommentViewModel credenciales, int id)
		{
			Response result = new Response();

			if (id != credenciales.IdPost)
			{
				result.result = 0;
				result.message = "Error en request.";
			}

			//validar usuario
			User usuario = GetUser(credenciales.userName, credenciales.password);

			if (usuario != null)
			{
				if (usuario.IdRoleNavigation.RoleOperations.Any())
				{
					Tuple<bool, List<int>> tplCheckAuth = CheckAuthorize(usuario, (int)EnumEntity.Post, (int)EnumOperation.Reject);

					if (tplCheckAuth.Item1)
					{
						if (tplCheckAuth.Item2 != null && tplCheckAuth.Item2.Any())
						{
							try
							{

									Post postSave = _context.Posts.Find(id);
									if (postSave != null)
									{
										string messageResult = EditStatusPost(postSave, _context, tplCheckAuth.Item2, 4, (int)EnumOperation.Reject);
										if (messageResult == "")
										{
											result.result = 1;

											// se crea el comentario
											if (!string.IsNullOrEmpty(credenciales.TextComment))
											{
												PostComment postComment = new PostComment()
												{
													TextComment = credenciales.TextComment,
													IdPost = id,
													IdUser = usuario.IdUser,
												};

											_context.PostComments.Add(postComment);
											_context.SaveChanges();
											}
										}
										else
										{
											result.result = 0;
											result.message = messageResult;
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
						else
						{
							result.result = 0;
							result.message = "No tiene permiso para esta acción.";
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
		private string EditStatusPost(Post postEdit, PostBDContext bd, List<int> lstValidStatusPost, int idNewStatus, int idOperation)
		{
			string error = "";

			try
			{
				if (lstValidStatusPost.Contains(postEdit.IdStatus))
				{
					if (idOperation == (int)EnumOperation.Approve)
						postEdit.PublishingDate = DateTime.Now;

					postEdit.IdStatus = idNewStatus;

					bd.Entry(postEdit).State = EntityState.Modified;
					bd.SaveChanges();

				}
				else
				{
					error = "No tiene permiso para esta acción.";
				}
			}
			catch (Exception ex)
			{
				error = "Ha ocurrido un error.";
			}

			return error;
		}
	}
}
