using Palindrom;
using WebApi.Persistence.Entities;

namespace WebApi.Persistence;

public class PalindromeRepository(PalindromeContext context): IPalindromeRepository
{
    public async Task AddPalindromeErgebnis(int eingabe, Palindromergebnis ergebnis)
    {
        context.Add(new PalindromeErgebnisDbo
        {
            Eingabe = eingabe,
            Palindrome = ergebnis.Palindrome,
            Zyklen = ergebnis.Zyklen
        }); 
        await context.SaveChangesAsync(); 
    }
}