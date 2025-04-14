// See https://aka.ms/new-console-template for more information
using Brainbay;
using Brainbay.Data;
using Microsoft.EntityFrameworkCore;

HttpClient client = new HttpClient()
{
    BaseAddress = new Uri("https://rickandmortyapi.com")
};

DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
optionsBuilder.UseSqlite("Data Source=Brainbay.db");

var dbContext = new BrainbayDbContext(optionsBuilder.Options);

var repo = new CharacterRepository(dbContext);

RickAndMortyService service = new RickAndMortyService(client, repo);
await service.FetchCharactersAsync();

dbContext.Dispose();
