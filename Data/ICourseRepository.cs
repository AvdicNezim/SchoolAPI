using SchoolAPI.Data.Entities;

namespace SchoolAPI.Data
{
    // Interface koji definira operacije za pristup podacima
    public interface ICourseRepository
    {
        IEnumerable<Course> allCourses { get; }
    }
}
