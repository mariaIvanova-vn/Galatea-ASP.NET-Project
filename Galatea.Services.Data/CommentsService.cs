using Galatea.Data.Models;
using Galatea.Services.Data.Interfaces;
using Galatea.Web.Data;
using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Galatea.Common.EntityValidationConstants;
using Comment = Galatea.Data.Models.Comment;

namespace Galatea.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly GalateaDbContext dbContext;

        public CommentsService(GalateaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CommentInputModel>> AllByPublicationIdAsync(string publicationId)
        {
            IEnumerable<CommentInputModel> allPublicationComment = await this.dbContext
                .Comments.Where(c=>c.PublicationId.ToString() == publicationId)
                .Select(p => new CommentInputModel
                {
                    Text = p.Text,
                    PublicationId = p.PublicationId.ToString(),
                    UserId = p.UserId.ToString(),
                }).ToArrayAsync();

            return allPublicationComment;
        }

        public async Task<string> CreateAsync(CommentInputModel commentInputModel)
        {
            var comment = new Comment()
            {
                Text = commentInputModel.Text,
                PublicationId = Guid.Parse(commentInputModel.PublicationId),
                UserId = Guid.Parse(commentInputModel.UserId),
            };

            await this.dbContext.AddAsync(comment);
            await this.dbContext.SaveChangesAsync();
            return comment.Id.ToString();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<CommentInputModel> GetCommentByPostId(string publicationId)
        //{
        //    Comment comment = await dbContext
        //        .Comments.FirstAsync(p => p.PublicationId.ToString() == publicationId);

        //    return new CommentInputModel
        //    {
        //        Id = comment.Id,
        //        PublicationId = comment.PublicationId,
        //        UserId = comment.UserId,
        //    };
        //}


    }
 }

