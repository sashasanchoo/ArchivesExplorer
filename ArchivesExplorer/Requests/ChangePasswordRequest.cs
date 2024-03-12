using System.ComponentModel.DataAnnotations;

namespace ArchivesExplorer.Requests
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = "The {0} can not be empty. ")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "The {0} can not be empty. ")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


        [Required(ErrorMessage = "The {0} can not be empty. ")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "The new password and the confirmation do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
