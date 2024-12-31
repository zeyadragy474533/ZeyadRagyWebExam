using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeyadRagyWebExam.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="You should enter title")]
        [MaxLength(100,ErrorMessage ="You should enter less than 100 letter")]
        public string Title { get; set; }
        [MaxLength(500, ErrorMessage = "You should enter less than 500 letter")]
        public string Description { get; set; }

        [RegularExpression("Pending|In progress|Completed" , ErrorMessage ="You should enter spacific status")]
        public string Status { get; set; }
        [RegularExpression("Low|Medium|High", ErrorMessage = "You should enter spacific status")]
        public string Priority { get; set; }

        [DataType(DataType.DateTime,ErrorMessage ="You should enter data form")]
        public DateTime Deadline { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [ForeignKey("TeamMember")]
        public int TeamMemberId { get; set; }

        public TeamMember TeamMember { get; set; }
    }
}
