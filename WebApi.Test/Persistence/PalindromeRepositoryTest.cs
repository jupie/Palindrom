using System.Net.Sockets;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Palindrom;
using WebApi.Persistence;
using WebApi.Persistence.Entities;
using WebApi.UseCaseInteractors;

namespace WebApi.Test.Persistence;

public class PalindromeRepositoryTest  
{
    [Theory( DisplayName = "Hinzufügen des Palindromes speichert es in der Datenbank")]
    [AutoData]
    public async Task AddPalindrome(int eingabe, Palindromergebnis ergebnis)
    {
        //arrange
        var options = new DbContextOptionsBuilder<PalindromeContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        using var context = new PalindromeContext(options);
        context.Database.EnsureCreated();
        var sut = new PalindromeRepository(context); 
        //act 
        await sut.AddPalindromeErgebnis(eingabe,ergebnis);
        //assert 
        using var context2 = new PalindromeContext(options);
        var resulting = await context2.PalindromeErgebnisse.FirstAsync(); 
        resulting.Eingabe.Should().Be(eingabe);
        resulting.Palindrome.Should().Be(ergebnis.Palindrome);
        resulting.Zyklen.Should().Be(ergebnis.Zyklen);
        await context2.Database.EnsureDeletedAsync();
    }
    [Theory( DisplayName = "Lesen liefert alle Palindrome zurück")]
    [AutoData]
    public async Task GetAllPalindromeTest(List<PalindromeReadModel> palindromes)
    {
        //arrange
        var options = new DbContextOptionsBuilder<PalindromeContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        using var context = new PalindromeContext(options);
        context.Database.EnsureCreated();
        palindromes.ForEach(model => 
            context.Add(new PalindromeErgebnisDbo
            {
                Eingabe = model.Eingabe,
                Palindrome = model.Palindrome,
                Zyklen = model.Zyklen,
            }));
        await context.SaveChangesAsync();
        var sut = new PalindromeRepository(context); 
        //act 
        var result = await sut.GetAll(); 
        //assert 
        result.Should().BeEquivalentTo(palindromes);
        using var context2 = new PalindromeContext(options);
        await context2.Database.EnsureDeletedAsync();
    }
   
}