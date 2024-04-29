using SchoolAPI.Data.Entities;

namespace SchoolAPI.Data
{
    // Interface koji definira operacije za pristup podacima
    public interface IStudentRepository
    {
        IEnumerable<Student> allStudents { get; }
        Student getById(int id);
        Student addStudent(Student student);
        Student updateStudent(Student student);
        bool removeStudent(int id);
    }
}
