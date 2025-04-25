using Palindrom;

namespace WebApi.UseCaseInteractors;

public interface IPalindromeInteractor
{
    Palindromergebnis BerechnePalindrome(int eingabe);
    Task SpeicherPalindrome(int eingabe);
    Task<List<PalindromeReadModel>> GebeAllePalindrome();
}