using SchoolAPI.Data.Entities;

namespace SchoolAPI.Data
{
    // Interface koji definira operacije za pristup podacima
    public interface IFinalRepository
    {
        IEnumerable<Final> allFinals { get; }
        Final getFinalById(int id);
        IEnumerable<Final> getFinalsByStudentId(int studentId);
        Final addFinal(Final final);
        Final updateFinal(Final final);
    }
}
