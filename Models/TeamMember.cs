using System.ComponentModel.DataAnnotations;

namespace ZeyadRagyWebExam.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "You should enter title")]
        [MaxLength(100, ErrorMessage = "You should enter less than 100 letter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You should enter title")]
        [MaxLength(100, ErrorMessage = "You should enter less than 100 letter")]
        public string Email { get; set; }
        [MaxLength(50, ErrorMessage = "You should enter less than 50 letter")]
        public string Role { get; set; }

        public ICollection<Job>? Jobs { get; set; }
    }
}
