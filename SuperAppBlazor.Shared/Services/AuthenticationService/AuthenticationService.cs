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
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<Authentication> Login(LoginUser loginUser)
    {
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(loginUser), 
            Encoding.UTF8, 
            "application/json");
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));
        
        try
        {
            // Log da tentativa de requisição
            Console.WriteLine($"Sending POST request to '/api/login' with payload: {JsonSerializer.Serialize(loginUser)}");

            var response = await _httpClient.PostAsync("/api/authentication/login", jsonContent, cts.Token);
            
            // Log da resposta recebida
            Console.WriteLine($"Received response: {response.StatusCode}");
                
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Authentication>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                Console.WriteLine("Login successful.");
                return result;
            }
            else
            {
                // Log de status HTTP não-sucedido
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Login failed with status code: {response.StatusCode}, response: {responseContent}");
            }

            return null;
        }
        catch (TaskCanceledException ex) when (!cts.IsCancellationRequested)
        {
            // Log the timeout exception
            Console.WriteLine("Login request timed out.");
            throw new TimeoutException("Login request timed out.", ex);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Authentication?> Register(RegisterUser user)
    {
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(user),
            Encoding.UTF8,
            "application/json");
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));

        try
        {
            // Log da tentativa de requisição
            Console.WriteLine(
                $"Sending POST request to '/api/authentication/register' with payload: {JsonSerializer.Serialize(user)}");

            var response = await _httpClient.PostAsync("/api/authentication/register", jsonContent, cts.Token);

            // Log da resposta recebida
            Console.WriteLine($"Received response: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Authentication>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                Console.WriteLine("Registro realizado com sucesso.");
                return result;
            }
            else
            {
                // Log de status HTTP não-sucedido
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Login failed with status code: {response.StatusCode}, response: {responseContent}");
            }

            return null;
        }
        catch (TaskCanceledException ex) when (!cts.IsCancellationRequested)
        {
            // Log the timeout exception
            Console.WriteLine("Login request timed out.");
            throw new TimeoutException("Login request timed out.", ex);
        }
        catch (Exception ex)
        {
            throw;

        }
    }
}