using System.Security.Authentication;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SMS.Grades.Domain;
using SMS.Grades.Domain.Abstractions.Repositories;
using SMS.Grades.Domain.Abstractions.Services;
using SMS.Grades.Domain.Abstractions.Settings;
using SMS.Grades.Repository;
using SMS.Grades.Repository.Context;
using SMS.Grades.Repository.Settings;
using SMS.Message.Abstractions.Services;
using SMS.Message.Services;

namespace SMS.Grades.Api.Common.DI;

public static class DependencyInjectionExtensions
{
    public static void ConfigureApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.UseRepositories(dbSettings => { dbSettings.ConnectionStringSQLite = configuration.GetValue<string>("ConnectionStrings:SQLite"); });
        services.UseServices();
        services.UseMassTransit(configuration);
    }

    private static void UseServices(this IServiceCollection service)
    {
        service.AddScoped<IGradeService, GradeService>();
        service.AddTransient<IBusService, BusService>();
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
        service.AddScoped<IGradeRepository, GradeRepository>();
    }

    private static void UseMassTransit(this IServiceCollection service, IConfiguration configuration)
    {
        var url = configuration["MessagesConfiguration:Url"];
        
        service.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(new Uri(url), h =>
                {
                    h.Username(configuration["MessagesConfiguration:Username"]);
                    h.Password(configuration["MessagesConfiguration:Password"]);
                
                    h.UseSsl(s =>
                    {
                        s.Protocol = SslProtocols.Tls12;
                    });
                });
                
                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
}