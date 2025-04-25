using AutoFixture.Xunit2;
using FluentAssertions;
using JetBrains.Annotations;
using Moq;
using Palindrom;
using WebApi.Persistence;
using WebApi.UseCaseInteractors;

namespace WebApi.Test.UseCaseInteractors;

public class PalindromeInteractorTest
{

    [Theory(DisplayName = "PalindromeInteractor verwendet Transformieren")]
    [AutoData]
    public void PalindromeInteractorTest01(int eingabe,Palindromergebnis ergebnis )
    {
        //arrange 
        var transformierenMock = new Mock<ITransformieren>();
        var repoMock = new Mock<IPalindromeRepository>(); 
        transformierenMock.Setup(transformieren => transformieren.PalindromeMitErgebnis(eingabe)).Returns(ergebnis);
        var sut = new PalindromeInteractor(transformierenMock.Object,repoMock.Object);
        //act 
        var result = sut.BerechnePalindrome(eingabe);
        //assert
        result.Should().BeEquivalentTo(ergebnis);
    }
    
    [Theory(DisplayName = "PalindromeInteractor transformiert erneut und speichert dann")]
    [AutoData]
    public async Task PalindromeInteractorTest02(int eingabe,Palindromergebnis ergebnis )
    {
        //arrange 
        var transformierenMock = new Mock<ITransformieren>();
        var repoMock = new Mock<IPalindromeRepository>(); 
        transformierenMock.Setup(transformieren => transformieren.PalindromeMitErgebnis(eingabe)).Returns(ergebnis);
        var sut = new PalindromeInteractor(transformierenMock.Object, repoMock.Object);
        //act 
        await sut.SpeicherPalindrome(eingabe);
        //assert
        repoMock.Verify(repository => repository.AddPalindromeErgebnis(eingabe,ergebnis), Times.Once);
    }
    
    [Theory(DisplayName = "PalindromeInteractor Gibt Anfrage nach allen weiter")]
    [AutoData]
    public async Task PalindromeInteractorTest03(List<PalindromeReadModel> palindromes)
    {
        //arrange 
        var transformierenMock = new Mock<ITransformieren>();
        var repoMock = new Mock<IPalindromeRepository>();
        repoMock.Setup(repository => repository.GetAll()).ReturnsAsync(palindromes);
        var sut = new PalindromeInteractor(transformierenMock.Object, repoMock.Object);
        //act 
        var result = await sut.GebeAllePalindrome();
        //assert
       result.Should().BeEquivalentTo(palindromes);
    }
}