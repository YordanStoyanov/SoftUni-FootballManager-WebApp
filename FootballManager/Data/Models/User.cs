namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        [Required]
        [StringLength(60)]
        public string Password { get; set; }
        public ICollection<UserPlayer> UsersPlayer { get; set; } = new List<UserPlayer>();
    }
}
