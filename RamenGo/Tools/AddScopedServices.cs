using RamenGo.Application.Repositories;
using RamenGo.Domain.Interfaces;

namespace RamenGo.Tools;
public static class AddScopedServices
{
    public static void AddScoped(this IServiceCollection services)
    {
        services.AddScoped<IBrothRepository, BrothRepository>()
                .AddScoped<IProteinRepository, ProteinRepository>()
                .AddScoped<IOrderRepository, OrderRepository>();
    }
}