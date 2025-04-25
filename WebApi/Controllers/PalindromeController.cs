using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Palindrom;
using WebApi.Controllers.Dto;
using WebApi.Persistence.Entities;
using WebApi.UseCaseInteractors;

namespace WebApi.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class PalindromeController
{
    private readonly IPalindromeInteractor _interactor;

    public PalindromeController(IPalindromeInteractor interactor)
    {
        _interactor = interactor;
    }

    [HttpGet("Berechne",Name = "Berechne Palindrom")]
    public Palindromergebnis GetPalindromeFor(int eingabe)
    {
        return _interactor.BerechnePalindrome(eingabe);
    }
    [HttpPost(Name = "Speicher Palindrom")]
    public async Task PostPalindrome([FromBody] EingabeDto eingabeDto)
    {
        await _interactor.SpeicherPalindrome(eingabeDto.Eingabe);
    }
    
    [HttpGet("AllePalindrome",Name = "Gebe Alle Palindrome")]
    public async Task<List<PalindromeReadModel>> GetAllPalindromes()
    {
      return  await _interactor.GebeAllePalindrome();
    }
    
}