using Galatea.Services.Data.Interfaces;
using Galatea.Web.ViewModels.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Galatea.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentService;
        public CommentsController(ICommentsService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CommentInputModel commentInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            await this.commentService.CreateAsync(commentInputModel);

            return this.RedirectToAction("Details", "Publication", new { id = commentInputModel.PublicationId });
        }
    }
}
