using Microsoft.EntityFrameworkCore;
using Palindrom;
using WebApi.Persistence.Entities;
using WebApi.UseCaseInteractors;

namespace WebApi.Persistence;

public class PalindromeRepository(PalindromeContext context): IPalindromeRepository
{
    public async Task AddPalindromeErgebnis(int eingabe, Palindromergebnis ergebnis)
    {
        context.Add(new PalindromeErgebnisDbo
        {
            Eingabe = eingabe,
            Palindrome = ergebnis.Palindrome,
            Zyklen = ergebnis.Zyklen
        }); 
        await context.SaveChangesAsync(); 
    }

    public async Task<List<PalindromeReadModel>> GetAll()
    {
       return await context.PalindromeErgebnisse.Select(dbo => new PalindromeReadModel(dbo.Eingabe, dbo.Palindrome, dbo.Zyklen)).ToListAsync(); 
    }
}