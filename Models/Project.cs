using System.ComponentModel.DataAnnotations;

namespace ZeyadRagyWebExam.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should enter title")]
        [MaxLength(100, ErrorMessage = "You should enter less than 100 letter")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "You should enter less than 100 letter")]
        public string Description { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "You should enter data form")]
        public DateTime StartDate { get; set; }


        [DataType(DataType.DateTime, ErrorMessage = "You should enter data form")]
        public DateTime EndDate { get; set; }

        public ICollection<Job>? Jobs { get; set; }

    }
}
