using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;

namespace SchoolAPI.Data
{
    // Klasa koja sluzi za pristup podacima o kursu iz baze podataka
    public class FinalRepository : IFinalRepository
    {
        private readonly AppDbContext _appDbContext;

        public FinalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Final> allFinals => _appDbContext.Finals;

        // Metoda koja dohvaca sve zavrsni ispit
        public Final getFinalById(int id)
        {
            return _appDbContext.Finals.Include(f => f.course).FirstOrDefault(f => f.id == id);
        }

        // Metoda koja dohvaca sve zavrsne ispite za odabranog studenta
        public IEnumerable<Final> getFinalsByStudentId(int studentId)
        {
            return _appDbContext.Finals.Include(f => f.course).Where(f => f.studentId == studentId);
        }

        // Metoda za dodavanje novog zavrsnog ispita
        public Final addFinal(Final final)
        {
            _appDbContext.Finals.Add(final);
            _appDbContext.SaveChanges();

            return final;
        }

        // Metoda za azuriranje informacija o zavrsnom ispitu
        public Final updateFinal(Final final)
        {
            Final updatedFinal = _appDbContext.Finals
                                 .FirstOrDefault(f => f.id == final.id && f.studentId == final.studentId);
            if (updatedFinal != null)
            {
                updatedFinal.mark = final.mark;
                updatedFinal.name = final.name;
                _appDbContext.SaveChanges();
            }

            return updatedFinal;
        }
    }
}
