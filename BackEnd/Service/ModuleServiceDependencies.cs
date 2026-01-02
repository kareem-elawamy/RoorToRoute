using Microsoft.Extensions.DependencyInjection;

namespace Service;

public static class ModuleServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        // Register infrastructure services here if needed
        
        return services;
    }

}
