using Palindrom;
using WebApi.UseCaseInteractors;

namespace WebApi.Persistence;

public interface IPalindromeRepository
{ 
    Task AddPalindromeErgebnis(int eingabe, Palindromergebnis ergebnisDbo);

    Task<List<PalindromeReadModel>> GetAll();
}