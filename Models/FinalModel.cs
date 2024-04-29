namespace SchoolAPI.Models
{
    // Model koji predstavlja DTO (Data Transfer Object)
    public class FinalModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public int mark { get; set; }
        public int courseId { get; set; }
        public CourseModel course { get; set; }
        public int studentId { get; set; }
    }
}
