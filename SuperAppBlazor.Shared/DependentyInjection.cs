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
        services.AddHttpContextAccessor();
        services.AddSingleton<CustomAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ISuperHeroService, SuperHeroService>();
        return services;
    }
}