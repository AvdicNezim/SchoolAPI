using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Data.Entities
{
    public class Student
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<Course> courses { get; set; }
        public int departmentId { get; set; }
        public Department department { get; set; }
    }
}
