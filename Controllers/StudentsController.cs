using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SchoolAPI.Data;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    // Kontroler za upravljanje studentima
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        // Konstruktor kontrolera za implementaciju potrebnih servisa i alata
        public StudentsController(IStudentRepository studentRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _studentRepository = studentRepository; // Repozitorij za pristup studenima
            _mapper = mapper; // AutoMapper za mapiranje između entiteta i DTO modela
            _linkGenerator = linkGenerator; // LinkGenerator za generiranje URL-ova
        }

        // Metoda za dohvacanje svih studenata ili studenata određenog odjela
        [HttpGet]
        public ActionResult<List<StudentModel>> Get(int? departmentId)
        {
            try
            {
                IEnumerable<Student> students = _studentRepository.allStudents;
                if (departmentId.HasValue)
                {
                    students = _studentRepository.allStudents.Where(s => s.departmentId == departmentId);
                }
                List<StudentModel> result = _mapper.Map<List<StudentModel>>(students);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Greska");
            }
        }

        // Metoda za dohvacanje odredjenog studenta
        [HttpGet("id")]
        public ActionResult<StudentModel> Get(int id)
        {
            try
            {
                Student student = _studentRepository.getById(id);
                StudentModel result = _mapper.Map<StudentModel>(student);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Greska");
            }
        }

        // Metoda za dodavanje novog studenta
        [HttpPost]
        public ActionResult<StudentModel> Post(StudentModel student)
        {
            try
            {
                Student studentDomainModel = _mapper.Map<Student>(student);
                var newStudentDM = _studentRepository.addStudent(studentDomainModel);
                StudentModel result = _mapper.Map<StudentModel>(newStudentDM);

                string location = _linkGenerator.GetPathByAction("Get", "Students", new { id = result.id });
                return Created(location, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Greska");
            }
        }

        // Metoda za azuriranje informacija o studentu
        [HttpPut]
        public ActionResult<StudentModel> Put(StudentModel student)
        {
            try
            {
                var studentDomainModel = _mapper.Map<Student>(student);
                var updatedStudent = _studentRepository.updateStudent(studentDomainModel);
                var result = _mapper.Map<StudentModel>(updatedStudent);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Greska");
            }
        }

        // Metoda za brisanje studenta
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool isSuccess = _studentRepository.removeStudent(id);

                return Ok(isSuccess);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Greska");
            }
        }
    }
}