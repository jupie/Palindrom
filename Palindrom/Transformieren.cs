namespace Palindrom;

public class Transformieren : ITransformieren
{
    private static int LIMIT = 1000000000;

    public Palindromergebnis PalindromeMitErgebnis(int N)
    {
        if (N < 0 || N > 1000)
        {
            throw new ArgumentException("N muss zwischen 1 und 1000 liegen");
        }
        return PalindromeMitErgebnis(N, 0);
    }
    private Palindromergebnis PalindromeMitErgebnis(int N, int zyklus )
    {
        if (IstPalindrome(N))
        {
            return new Palindromergebnis(N, zyklus);
        }
        if (IstOverLimit(N))
        {
            return new Palindromergebnis(-1, zyklus);
        }
        var newN = BerechneNeuesN(N);
        zyklus += 1; 
        return PalindromeMitErgebnis(newN, zyklus);
    }
    private int BerechneNeuesN(int number)
    {
        var numberString = number.ToString();
        var reverseNumberstring = new string (numberString.Reverse().ToArray());
        return int.Parse(reverseNumberstring!) + number;
    }

    private bool IstOverLimit(int i)
    {
        return i > LIMIT; 
    }

    public int Palindrome(int N)
    {
        var result = PalindromeMitErgebnis(N);
        return result.Palindrome;
    }

    private bool IstPalindrome(int number)
    {
        var numberString = number.ToString();
        var reverseNumberstring = new string (numberString.Reverse().ToArray());
        return numberString.Equals(reverseNumberstring);
    }
}