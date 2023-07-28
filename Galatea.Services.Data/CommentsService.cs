using Galatea.Data.Models;
using Galatea.Services.Data.Interfaces;
using Galatea.Web.Data;
using Galatea.Web.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galatea.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly GalateaDbContext dbContext;

        public CommentsService(GalateaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(CommentInputModel commentInputModel)
        {
            var comment = new Comment()
            {
                Text = commentInputModel.Text,
                PublicationId = commentInputModel.PublicationId,
                UserId = commentInputModel.UserId,
            };

            await this.dbContext.AddAsync(comment);
            await this.dbContext.SaveChangesAsync();
            return comment.Id;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
