
using System.Net.Http.Json;
using Brainbay;
using Brainbay.Models;
using Brainbay.Models.Dtos;
using Models;

public class RickAndMortyService(HttpClient httpClient, CharacterRepository repo)
{

    public async Task FetchCharactersAsync()
    {
        await repo.DeleteAll();

        int page = 1;
        bool hasNext = true;

        while (hasNext)
        {
            var response = await httpClient.GetFromJsonAsync<ApiResponse<ApiCharacter>>($"/api/character?page={page}&status=alive"); ;

            if (response == null)
            {
                return;
            }

            Console.WriteLine($"Downloaded page {page}");
            StoreCharacterBatchAsync(response.Results);

            page++;
            hasNext = response.Info.Next != null;
        }

        return;
    }

    private void StoreCharacterBatchAsync(IEnumerable<ApiCharacter> batch)
    {
        batch
            .ToList()
            .ForEach(async character =>
            {
                await repo.Create(new CharacterDto()
                {
                    Name = character.Name,
                    Type = character.Type,
                    Status = character.Status,
                    Gender = character.Gender,
                    Location = character.Location?.Name,
                    Origin = character.Origin?.Name,
                    Species = character.Species
                });
            });
    }

}
