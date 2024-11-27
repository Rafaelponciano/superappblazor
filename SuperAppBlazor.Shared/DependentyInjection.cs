using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using SuperAppBlazor.Shared.Domain;
using SuperAppBlazor.Shared.Services.AuthenticationService;
using SuperAppBlazor.Shared.Services.SuperHeroService;

namespace SuperAppBlazor.Shared;

public static class DependentyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddScoped<ISuperHeroService, SuperHeroService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());
        services.AddSingleton<CustomAuthenticationStateProvider>();
        
        services.AddHttpClient("MyHttpClient", client =>
        {
            // Definindo timeout, por exemplo, 200 segundos
            client.BaseAddress = new Uri("https://localhost:7158/");
            client.Timeout = TimeSpan.FromSeconds(200);
        });

        services.AddScoped<IAuthenticationService, AuthenticationService>(sp =>
        {
            var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyHttpClient");
    
            return new AuthenticationService(httpClient);
        });
        
        services.AddScoped<ISuperHeroService, SuperHeroService>(sp =>
        {
            var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyHttpClient");
    
            return new SuperHeroService(httpClient);
        });
        
        return services;
    }
}