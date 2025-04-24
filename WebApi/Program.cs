using Microsoft.EntityFrameworkCore;
using Palindrom;
using WebApi.Persistence;
using WebApi.UseCaseInteractors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); 
builder.Services.AddScoped<ITransformieren, Transformieren>(); 
builder.Services.AddScoped<IPalindromeInteractor, PalindromeInteractor>(); 
builder.Services.AddScoped<IPalindromeRepository, PalindromeRepository>();
builder.Services.AddDbContext<PalindromeContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase("aDatabaseName")); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meine API v1");
        c.RoutePrefix = string.Empty; // Swagger unter root anzeigen
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();