using FluentAssertions;

namespace Palindrom.Test;

public class TransformierenTest
{
    [Theory(DisplayName = "Transformieren findet das passende Palindrom")]
    [InlineData(121, 121)]
    [InlineData(34543, 34543)]
    [InlineData(11, 11)]
    [InlineData(28, 121)]
    [InlineData(51, 66)]
    [InlineData(607, 4444)]
    public void PalindromTest01(int n, int expected)
    {
        //arrange
        var sut  = new Transformieren();
        //act 
        var result = sut.Palindrome(n); 
        //assert 
        result.Should().Be(expected);
    }
    
    [Theory(DisplayName = "Transformieren mit ungültiger Eingabe wirft eine Exception")]
    [InlineData(0)]
    [InlineData(1001)]
    public void PalindromTest02(int n)
    {
        //arrange
        var sut  = new Transformieren();
        //act 
        var action = () => sut.Palindrome(n); 
        //assert 
        action.Should().Throw<ArgumentException>();
    }
    
    [Theory(DisplayName = "Transformieren eines Pallindroms über 1.000.000.000 gibt -1 zurück")]
    [InlineData(196, -1)]
    public void PalindromTest03(int n, int expected)
    {
        //arrange
        var sut  = new Transformieren();
        //act 
        var result = sut.Palindrome(n); 
        //assert 
        result.Should().Be(expected);
    }
    
    [Theory(DisplayName = "PalindromeMitErgebnis findet das passende Palindrom mit passender Zyklenzahl")]
    [InlineData(28, 121,2)]
    [InlineData(51, 66,1)]
    [InlineData(11, 11,0)]
    public void PalindromTest04(int n, int expected, int zyklenzahl)
    {
        //arrange
        var sut  = new Transformieren();
        //act 
        var result = sut.PalindromeMitErgebnis(n); 
        //assert 
        result.Palindrome.Should().Be(expected);
        result.Zyklen.Should().Be(zyklenzahl);
    }
    
    
}