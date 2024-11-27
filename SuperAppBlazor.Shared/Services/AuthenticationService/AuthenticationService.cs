using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using SuperAppBlazor.Shared.Domain;
using SuperAppBlazor.Shared.Services.AuthenticationService.Models;
using SuperAppBlazor.Shared.Services.SuperHeroService.Models;

namespace SuperAppBlazor.Shared.Services.AuthenticationService;

public class AuthenticationService: IAuthenticationService
{
    private readonly HttpClient _httpClient;
    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Authentication?> Login(LoginUser loginUser)
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(loginUser), Encoding.UTF8, "application/json");
            // Faz a requisição HTTP para a API
            HttpResponseMessage response = await _httpClient.PostAsync("/api/Authentication/login", content);

            // Log da resposta JSON
            string jsonString = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<Authentication>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                    
                // Retorna a lista de SuperHero do resultado envoltório
                return result;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Authentication?> Register(RegisterUser user)
    {
        return await _httpClient.GetFromJsonAsync<Authentication>("api/authentication/register");
    }
}