using SuperAppBlazor.Shared.Domain;

namespace SuperAppBlazor.Shared.Services.SuperHeroService;

public interface ISuperHeroService
{
    SuperHero Insert(SuperHero insertHero);
    Task<SuperHero>  Update(SuperHero updateHero);
    void Delete(int id);
    
    Task<List<SuperHero>?> GetAll();
    Task<SuperHero?> GetById(int id);
}