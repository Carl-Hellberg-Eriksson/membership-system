using MembershipSystem.Core.Interfaces;
using MembershipSystem.Infrastructure.Repository;
using MembershipSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
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
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config) {
        services.AddTransient<IExample, Example>();
        services.AddTransient<IPersonService, PersonService>();

        //Database
        services.AddDbContext<DatabaseContext>(options => {
            var connectionstring = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });
        services.AddTransient<IPersonRepository, PersonRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
