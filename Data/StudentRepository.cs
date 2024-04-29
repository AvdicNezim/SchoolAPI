using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Entities;

namespace SchoolAPI.Data
{
    // Klasa koja sluzi za pristup podacima o kursu iz baze podataka
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Student> allStudents => _appDbContext.students.Include(s => s.department);

        // Metoda koja dohvaca studenta
        public Student getById(int id)
        {
            return _appDbContext.students.FirstOrDefault(s => s.id == id);
        }

        // Metoda za dodavanje novog studenta
        public Student addStudent(Student student)
        {
            _appDbContext.students.Add(student);
            _appDbContext.SaveChanges();
            return student;
        }

        // Metoda za azuriranje informacija o studentu
        public Student updateStudent(Student student)
        {
            Student updatedStudent = _appDbContext.students.FirstOrDefault(s => s.id == student.id);
            if (updatedStudent != null)
            {
                updatedStudent.firstName = student.firstName;
                updatedStudent.lastName = student.lastName;
                updatedStudent.departmentId = student.departmentId;
                _appDbContext.SaveChanges();
            }
            return updatedStudent;
        }

        // Metoda za brisanje studenta
        public bool removeStudent(int id)
        {
            bool isSuccessful = false;
            Student student = getById(id);
            if (student != null)
            {
                _appDbContext.students.Remove(student);
                _appDbContext.SaveChanges();
                isSuccessful = true;
            }
            return isSuccessful;
        }
    }
}