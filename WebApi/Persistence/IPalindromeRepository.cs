using Palindrom;

namespace WebApi.Persistence;

public interface IPalindromeRepository
{ 
    Task AddPalindromeErgebnis(int eingabe, Palindromergebnis ergebnisDbo);
    
}