using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Models
{
    // Model koji predstavlja DTO (Data Transfer Object)
    public class StudentModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(20)]
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Required]
        public int departmentId { get; set; }
        public string? departmentName { get; set; }
    }
}
