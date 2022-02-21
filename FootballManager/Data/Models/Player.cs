namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Player
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20)]
        public string Position { get; set; }

        [Required]
        [Range(0, 10)]
        public byte Speed { get; set; }

        [Required]
        [Range(0, 10)]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new List<UserPlayer>();
    }
}
