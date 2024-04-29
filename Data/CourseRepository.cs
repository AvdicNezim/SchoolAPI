using SchoolAPI.Data.Entities;

namespace SchoolAPI.Data
{

    // Klasa koja sluzi za pristup podacima o kursu iz baze podataka
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Course> allCourses => _appDbContext.courses;
    }
}
