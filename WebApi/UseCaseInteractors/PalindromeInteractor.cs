using Palindrom;
using WebApi.Persistence;

namespace WebApi.UseCaseInteractors;

public class PalindromeInteractor : IPalindromeInteractor
{
    
    private readonly ITransformieren _transformieren;
    private readonly IPalindromeRepository _repo;

    public PalindromeInteractor(ITransformieren transformieren, IPalindromeRepository repo)
    {
        _transformieren = transformieren;
        _repo = repo;
    }

    public Palindromergebnis BerechnePalindrome(int eingabe)
    {
       return _transformieren.PalindromeMitErgebnis(eingabe);
    }

    public async Task SpeicherPalindrome(int eingabe)
    {
        var result = BerechnePalindrome(eingabe);
        await _repo.AddPalindromeErgebnis(eingabe, result);
    }
}