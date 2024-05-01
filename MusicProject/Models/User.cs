using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MusicProject.Models;
    public class User : IdentityUser
    {

    //[Key]
    //public int Id { get; set; }
    // public byte[]? ProfileImage { get; set; }

    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public ICollection<UserFavorite>? FavoriteTracks { get; set; }


    //[Required(ErrorMessage = "The UserName field is required.")]
    //[RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username can only contain letters or digits.")]
    //public string UserName { get; set; }

    //[StringLength(100)]
    //[MaxLength(100)]
    //[Required]
    //public string Username { get; set; } = null!;

    //public string? Email { get; set; } 

    //public string Password { get; set; } = null!;
}

