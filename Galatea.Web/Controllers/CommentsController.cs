using Galatea.Data.Models;
using Galatea.Services.Data;
using Galatea.Services.Data.Interfaces;
using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Galatea.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentService;
        private readonly IPublicationService publicationService;
        public CommentsController(ICommentsService commentService, IPublicationService publicationService)
        {
            this.commentService = commentService;
            this.publicationService = publicationService;

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CommentInputModel commentInputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Details", "Publication", new { id = commentInputModel.PublicationId });
            }
            try
            {
                await this.commentService.CreateAsync(commentInputModel);

                return this.RedirectToAction("Details", "Publication", new { id = commentInputModel.PublicationId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Грешка при добавянето на коментар. Моля опитайте по-късно!");

                return RedirectToAction("Index", "Home");
            }           
        }

        [Authorize]
        public async Task<IActionResult> Delete(int commentId)
        {
            var currentUrl = this.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Referer").Value;
            var announcementId = await this.commentService.DeleteAsync(commentId);
            return this.Redirect(currentUrl);
        }

        //[HttpGet]
        //public async Task<IActionResult> PublicationComments()
        //{
        //    var publicationComments = new List<CommentInputModel>();

        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    string publicationId = 

        //    publicationComments.AddRange(await commentService.AllByPublicationIdAsync(userId));

        //    return View(publicationComments);
        //}
    }
}
