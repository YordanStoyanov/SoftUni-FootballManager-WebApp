namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class UserPlayer
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
    }
}
