namespace SchoolAPI.Data.Entities
{
    public class Final
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public int mark { get; set; }
        public int courseId { get; set; }
        public Course course { get; set; }
        public int studentId { get; set; }
        public Student student { get; set; }
    }
}
