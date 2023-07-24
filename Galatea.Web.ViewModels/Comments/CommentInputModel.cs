
namespace Galatea.Web.ViewModels.Comments
{
    public class CommentInputModel 
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public Guid UserId { get; set; } 

        public Guid PublicationId { get; set; } 
    }
}
