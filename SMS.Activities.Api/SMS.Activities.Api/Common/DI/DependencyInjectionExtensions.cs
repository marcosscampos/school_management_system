using Microsoft.EntityFrameworkCore;
using SMS.Activities.Domain;
using SMS.Activities.Domain.Abstractions.Repositories;
using SMS.Activities.Domain.Abstractions.Services;
using SMS.Activities.Domain.Abstractions.Settings;
using SMS.Activities.Repository;
using SMS.Activities.Repository.Context;
using SMS.Activities.Repository.Settings;

namespace SMS.Activities.Api.Common.DI;

public static class DependencyInjectionExtensions
{
    public static void ConfigureApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.UseRepositories(dbSettings => { dbSettings.ConnectionStringSQLite = configuration.GetValue<string>("ConnectionStrings:SQLite"); });
        services.UseServices();
    }

    private static void UseServices(this IServiceCollection service)
    {
        service.AddHttpClient();
        service.AddScoped<IActivityService, ActivityService>();
    }

    private static void UseRepositories(this IServiceCollection service, Action<IDbSettings> dbSettings)
    {
        using var scope = service.BuildServiceProvider().CreateScope();
        using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
        {
            context?.Database.EnsureCreated();
        }

        IDbSettings configureDb = new DbSettings();
        dbSettings.Invoke(configureDb);
        service.AddSingleton(configureDb);

        service.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configureDb.ConnectionStringSQLite));
        service.AddScoped<IActivityRepository, ActivityRepository>();
    }
}