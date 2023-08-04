﻿using Galatea.Data.Models;
using Galatea.Services.Data;
using Galatea.Services.Data.CommentServiceModel;
using Galatea.Services.Data.Interfaces;
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;
using Galatea.Web.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Galatea.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        private readonly IUsersService userService;
        private readonly ICommentsService commentService;
        public UsersController(UserManager<AppUser> userManager, IUsersService userService, ICommentsService commentService)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.commentService = commentService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> UserProfile(string id)
        {
            var user = await this.userService.GetUser(id);

            var userId = await this.userService.GetUserIdAsync();
            user.Comments = (ICollection<CommentViewModel>)await this.commentService.GetCommentByUserIdAsync(userId!);
  
            return this.View(user);
        }
    }
}
