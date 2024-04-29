using AutoMapper;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;

namespace SchoolAPI.Data
{
    // Klasa koja definira mapiranje izmedju entiteta Student i DTO modela StudentModel pomocu AutoMappera
    public class StudentProfile : Profile
    {
        // Konstruktor klase u kojem se definira mapiranje
        public StudentProfile()
        {
            this.CreateMap<Student, StudentModel>();
            this.CreateMap<StudentModel, Student>();
        }
    }
}
