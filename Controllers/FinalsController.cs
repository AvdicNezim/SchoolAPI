using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Data;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    // Kontroler za upravljanje zavrsnim ispitima studenata
    [Route("api/students/{studentId}/[controller]")]
    [ApiController]
    public class FinalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IFinalRepository _finalRepository;

        // Konstruktor kontrolera za implementaciju potrebnih servisa i alata
        public FinalsController(IMapper mapper, LinkGenerator linkGenerator, IFinalRepository finalRepository)
        {
            _mapper = mapper; // AutoMapper za mapiranje između entiteta i DTO modela
            _linkGenerator = linkGenerator; // LinkGenerator za generiranje URL-ova
            _finalRepository = finalRepository; // Repozitorij za pristup zavrsnim ispitima
        }

        // Metoda za dohvacanje svih zavrsnih ispita odredjenog studenta
        [HttpGet]
        public ActionResult<List<FinalModel>> Get(int studentId)
        {
            try
            {
                List<FinalModel> result = new List<FinalModel>();

                var finals = _finalRepository.getFinalsByStudentId(studentId);
                result = _mapper.Map<List<FinalModel>>(finals);

                return result;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Greska");
            }
        }

        // Metoda za dohvacanje pojedinog zavrsnog ispita odredjenog studenta
        [HttpGet("id")]
        public ActionResult<FinalModel> Get(int studentId, int id)
        {
            try
            {
                FinalModel result = null;

                var finalDM = _finalRepository.getFinalById(id);
                if (finalDM != null && finalDM.studentId == studentId)
                {
                    result = _mapper.Map<FinalModel>(finalDM);
                }

                return result;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Greska");
            }
        }

        // Metoda za dodavanje novog zavrsnog ispita za odredjenog studenta
        [HttpPost]
        public ActionResult<FinalModel> Post(int studentId, FinalModel final)
        {
            try
            {
                FinalModel result = null;

                Final finalDM = _mapper.Map<Final>(final);
                finalDM.studentId = studentId;
                Final finalResult = _finalRepository.addFinal(finalDM);
                result = _mapper.Map<FinalModel>(finalResult);

                return result;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Greska");
            }
        }

        // Metoda za azuriranje informacija o zavrsnom ispitu odredjenog studenta
        [HttpPut]
        public ActionResult<FinalModel> Put(int studentId, int id, FinalModel final)
        {
            try
            {
                FinalModel result = null;

                Final finalDM = _mapper.Map<Final>(final);
                finalDM.studentId = studentId;
                finalDM.id = id;
                var finalDMResult = _finalRepository.updateFinal(finalDM);
                result = _mapper.Map<FinalModel>(finalDMResult);

                return result;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Greska");
            }
        }
    }
}