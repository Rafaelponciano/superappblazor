using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using SuperAppBlazor.Shared.Domain;
using SuperAppBlazor.Shared.Services.SuperHeroService.Models;

namespace SuperAppBlazor.Shared.Services.SuperHeroService;

public class SuperHeroService: ISuperHeroService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<SuperHeroService> _logger;
    
    public SuperHeroService(HttpClient httpClient, ILogger<SuperHeroService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public SuperHero Insert(SuperHero insertHero)
    {
        throw new NotImplementedException();
    }

    public async Task<SuperHero> Update(SuperHero updateHero)
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(updateHero), Encoding.UTF8, "application/json");
            // Faz a requisição HTTP para a API
            HttpResponseMessage response = await _httpClient.PutAsync("/api/SuperHero", content);

            // Log da resposta JSON
            string jsonString = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                var resultWrapper = JsonSerializer.Deserialize<GetSuperHero>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                    
                // Retorna a lista de SuperHero do resultado envoltório
                return resultWrapper?.Result;
            }
            else
            {
                return null;
            }
        }
        catch (JsonException ex)
        {
            // Log detalhado para erro de desserialização
            _logger.LogError($"JSON deserialization error: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            // Log detalhado para outros erros
            _logger.LogError($"JSON deserialization error: {ex.Message}");
            return null;
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SuperHero>?> GetAll()
    {
        try
        {
            // Faz a requisição HTTP para a API
            HttpResponseMessage response = await _httpClient.GetAsync("/api/SuperHero");

            // Log da resposta JSON
            string jsonString = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                var resultWrapper = JsonSerializer.Deserialize<SuperHeroResult>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                    
                // Retorna a lista de SuperHero do resultado envoltório
                return resultWrapper?.Result;
            }
            else
            {
                return new List<SuperHero>();
            }
        }
        catch (JsonException ex)
        {
            // Log detalhado para erro de desserialização
            _logger.LogError($"JSON deserialization error: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            // Log detalhado para outros erros
            _logger.LogError($"JSON deserialization error: {ex.Message}");
            return null;
        }
    }

    public async Task<SuperHero?> GetById(int id)
    {
        try
        {
            // Faz a requisição HTTP para a API
            HttpResponseMessage response = await _httpClient.GetAsync("/api/SuperHero/"+id);

            // Log da resposta JSON
            string jsonString = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                var resultWrapper = JsonSerializer.Deserialize<GetSuperHero>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                    
                // Retorna a lista de SuperHero do resultado envoltório
                return resultWrapper?.Result;
            }
            else
            {
                return null;
            }
        }
        catch (JsonException ex)
        {
            // Log detalhado para erro de desserialização
            _logger.LogError($"JSON deserialization error: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            // Log detalhado para outros erros
            _logger.LogError($"JSON deserialization error: {ex.Message}");
            return null;
        }
    }
}