using MusicProject.Models;
using MusicProject.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MusicProject.Areas.admin.ViewModels
{
    public class AdminViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int TotalUsers { get; set; }
        // Add more properties as needed for your admin view
        public List<User> Users { get; set; }
        // Constructor to initialize properties
        public Dictionary<string, int> UserIdMap { get; set; }

        //public IndexViewModel IndexViewModel { get; set; }
        public User User { get; set; }

        public AdminViewModel()
        {
            // Initialize properties or leave them null/default
            User = new User();
        }
        public AdminViewModel(int totalUsers)
        {
            TotalUsers = totalUsers;
            Users = new List<User>();
            UserIdMap = new Dictionary<string, int>();
            

        }
    }
}
