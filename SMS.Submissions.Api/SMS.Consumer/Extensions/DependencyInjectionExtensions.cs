using System.Security.Authentication;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Consumer.Consumers;

namespace SMS.Consumer.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection ConfigureConsumerApplicationDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.UseMassTransit(configuration);

        return services;
    }

    private static void UseMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var url = configuration["MessagesConfiguration:Url"];

        services.AddMassTransit(x =>
        {
            x.AddConsumer<GradeConsumer>();
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
                
                cfg.ReceiveEndpoint(configuration["MessagesConfiguration:Queues:Grade"], ep =>
                {
                    ep.PrefetchCount = 10;
                    ep.UseMessageRetry(r => r.Interval(2, 100));
                    ep.ConfigureConsumer<GradeConsumer>(ctx);
                });
                
                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
}