using Microsoft.AspNetCore.Mvc;
using Palindrom;
using WebApi.Controllers.Dto;
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

    [HttpGet(Name = "BerechnePalindrom")]
    public Palindromergebnis GetPalindromeFor(int eingabe)
    {
        return _interactor.BerechnePalindrome(eingabe);
    }
    [HttpPost(Name = "SpeicherPalindrom")]
    public async Task PostPalindrome([FromBody] EingabeDto eingabeDto)
    {
        await _interactor.SpeicherPalindrome(eingabeDto.Eingabe);
    }
    
}