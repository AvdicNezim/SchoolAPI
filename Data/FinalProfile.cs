using AutoMapper;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;

namespace SchoolAPI.Data
{
    // Klasa koja definira mapiranje izmedju entiteta Final, Course i njihovih DTO modela pomocu AutoMappera
    public class FinalProfile : Profile
    {
        // Konstruktor klase u kojem se definira mapiranje
        public FinalProfile()
        {
            this.CreateMap<Final, FinalModel>();
            this.CreateMap<FinalModel, Final>();
            this.CreateMap<Course, CourseModel>();
        }
    }
}
