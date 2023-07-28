using Galatea.Web.ViewModels.Comments;


namespace Galatea.Services.Data.Interfaces
{
    public interface ICommentsService
    {
        Task<int> CreateAsync(CommentInputModel commentInputModel);

        

        Task<int> DeleteAsync(int id);
    }
}
