using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MusicProject.Models;
    public class User : IdentityUser
    {

    //[Key]
     public int Id { get; set; } 

    //[StringLength(100)]
    //[MaxLength(100)]
    //[Required]
    //public string Username { get; set; } = null!;

    //public string? Email { get; set; } 

    //public string Password { get; set; } = null!;
    }

