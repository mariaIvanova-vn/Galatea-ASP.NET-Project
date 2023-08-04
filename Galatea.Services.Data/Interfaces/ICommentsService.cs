using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;

namespace Galatea.Services.Data.Interfaces
{
    public interface ICommentsService
    {
        Task<string> CreateAsync(CommentInputModel commentInputModel);

        //Task<CommentInputModel> GetCommentByPostId(string publicationId);

        Task<IEnumerable<CommentInputModel>> AllByPublicationIdAsync(string publicationId);

        Task<int> DeleteAsync(int id);       
    }
}
