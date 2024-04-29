namespace SchoolAPI.Models
{
    // Model koji predstavlja DTO (Data Transfer Object)
    public class CourseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int numberOfClasses { get; set; }
    }
}
