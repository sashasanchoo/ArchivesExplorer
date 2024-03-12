using System.ComponentModel.DataAnnotations;

namespace ArchivesExplorer.Requests
{
    public class CreateCommentRequest
    {
        [Required(ErrorMessage = "The comment's content can not be empty. ")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Content { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
