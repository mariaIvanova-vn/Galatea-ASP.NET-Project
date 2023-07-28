

namespace Galatea.Web.ViewModels.Comments
{
    public class CommentViewModel 
    {
        public int Id { get; set; }

        public string Text { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string UserProfilePictureUrl { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string PublicationId { get; set; } = null!;
    }
}
