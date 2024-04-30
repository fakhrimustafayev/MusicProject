using System.ComponentModel.DataAnnotations;

namespace MusicProject.ViewModels
{
    public class EditUserViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required]
        public string? UserName { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string?  Email { get; set; }

        public string? Password { get; set; }

        [Display(Name = "Phone number")]
        [Phone]
        public string? PhoneNumber { get; set; }

    }
}
