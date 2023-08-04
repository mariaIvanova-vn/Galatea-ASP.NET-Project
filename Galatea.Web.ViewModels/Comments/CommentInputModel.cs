
namespace Galatea.Web.ViewModels.Comments
{
    public class CommentInputModel 
    {
        public int Id { get; set; }

        public string Text { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string PublicationId { get; set; } = null!;
    }
}
