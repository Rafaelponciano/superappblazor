using SuperAppBlazor.Shared.Domain;
using SuperAppBlazor.Shared.Services.SuperHeroService.Models;

namespace SuperAppBlazor.Shared.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<SuperHero> Insert(InsertSuperHero insertHero);
    Task<SuperHero>  Update(SuperHero updateHero);
    void Delete(int id);
    
    Task<List<SuperHero>?> GetAll();
    Task<SuperHero?> GetById(int id);
}