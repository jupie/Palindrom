using Palindrom;

namespace WebApi.Persistence;

public class PalindromeRepository(PalindromeContext context): IPalindromeRepository
{
    public Task AddPalindromeErgebnis(Palindromergebnis ergebnisDbo)
    {
        throw new NotImplementedException();
    }
}