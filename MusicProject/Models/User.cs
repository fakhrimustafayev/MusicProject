using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MusicProject.Models;
    public class User : IdentityUser
    {
    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public ICollection<UserFavorite>? FavoriteTracks { get; set; }



}

