using MembershipSystem.Core.Interfaces;
using MembershipSystem.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MembershipSystem.Infrastructure;

/// <summary>
/// Holds extension methods for registering infrastructure components for
/// dependency injection.
/// </summary>
public static class ServiceRegistration {
    /// <summary>
    /// Adds needed infrastructure components.
    /// </summary>
    public static void AddInfrastructure(this IServiceCollection services) {
        services.AddTransient<IExample, Example>(); 
    }
}
