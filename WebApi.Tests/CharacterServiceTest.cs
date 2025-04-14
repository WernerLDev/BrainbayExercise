using Brainbay;
using Brainbay.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Services;

namespace WebApi.Tests;

public class CharacterServiceTest
{
  [Fact]
  public void ShouldFetchAllCharacters()
  {

    var repoMock = new Mock<ICharacterRepository>();
    repoMock.Setup(repo => repo.All()).Returns([
      new Character() {
        Id = 1,
        Name = "Test Char",
        Gender = "Male"
      },
      new Character() {
        Id = 2,
        Name = "Someone",
        Gender = "Male"
      },
    ]);

    var services = new ServiceCollection();
    services.AddMemoryCache();
    var serviceProvider = services.BuildServiceProvider();

    var memoryCache = serviceProvider.GetService<IMemoryCache>();

    var service = new CharacterService(repoMock.Object, memoryCache);

    var allCharacters = service.GetAll();
    Assert.Equal(2, allCharacters.Count());
    repoMock.Verify(repo => repo.All(), Times.Once());

    service.SetCache(allCharacters);
    var cached = service.TryGetAllCache();
    Assert.NotNull(cached);
    Assert.Equal(2, cached.Count());
  }
}
