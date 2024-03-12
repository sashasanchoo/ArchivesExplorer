using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ArchivesExplorer.Requests
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "The {0} can not be empty.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [RegularExpression(@"[a-zA-Z0-9._]+", ErrorMessage = "The {0} must contain notning except alphabetic characters, digits, \".\" or \"_\" symbols.")]
        public string Username { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "The {0} can not be empty.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "The {0} can not be empty.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "The password and the confirmation do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The {0} can not be empty.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
