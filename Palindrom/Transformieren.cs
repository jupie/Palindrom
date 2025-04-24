namespace Palindrom;

public class Transformieren : ITransformieren
{
    public Palindromergebnis PalindromeMitErgebnis(int N)
    {
        throw new NotImplementedException();
    }
    public int Palindrome(int N)
    {
        var result = PalindromeMitErgebnis(N);
        return result.Palindrome;
    }
}