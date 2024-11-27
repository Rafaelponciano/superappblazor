using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using SuperAppBlazor.Shared.Domain;
using SuperAppBlazor.Shared.Services.SuperHeroService.Models;

namespace SuperAppBlazor.Shared.Services.SuperHeroService;

public class SuperHeroService: ISuperHeroService
{
    private readonly HttpClient _httpClient;
    
    public SuperHeroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<SuperHero> Insert(InsertSuperHero insertHero)
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(insertHero), Encoding.UTF8, "application/json");
            // Faz a requisição HTTP para a API
            HttpResponseMessage response = await _httpClient.PostAsync("/api/SuperHero", content);

            // Log da resposta JSON
            string jsonString = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                var resultWrapper = JsonSerializer.Deserialize<SuperHero>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                    
                // Retorna a lista de SuperHero do resultado envoltório
                return resultWrapper;
            }
            else
            {
                return null;
            }
        }
        catch (JsonException ex)
        {
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
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
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<SuperHero>?> Delete(int id)
    {
        try
        {
            // Faz a requisição HTTP para a API
            HttpResponseMessage response = await _httpClient.DeleteAsync("/api/SuperHero/"+id);

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
                return null;
            }
        }
        catch (JsonException ex)
        {
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
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
            return null;
        }
        catch (Exception ex)
        {
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
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}