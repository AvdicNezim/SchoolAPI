namespace SchoolAPI.Data.Entities
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int numberOfClasses { get; set; }
        public List<Student> students { get; set; }
    }
}
