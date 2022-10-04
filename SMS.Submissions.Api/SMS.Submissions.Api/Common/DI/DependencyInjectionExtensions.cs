using MassTransit;
using Microsoft.EntityFrameworkCore;
using SMS.Submissions.Domain;
using SMS.Submissions.Domain.Abstractions.Repositories;
using SMS.Submissions.Domain.Abstractions.Services;
using SMS.Submissions.Domain.Abstractions.Settings;
using SMS.Submissions.Repository;
using SMS.Submissions.Repository.Context;
using SMS.Submissions.Repository.Settings;

namespace SMS.Submissions.Api.Common.DI;

public static class DependencyInjectionExtensions
{
    public static void ConfigureApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.UseRepositories(dbSettings => { dbSettings.ConnectionStringSQLite = configuration.GetValue<string>("ConnectionStrings:SQLite"); });
        services.UseServices();
    }

    private static void UseServices(this IServiceCollection service)
    {
        service.AddScoped<ISubmissionService, SubmissionService>();
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
        service.AddScoped<ISubmissionRepository, SubmissionRepository>();
    }
}