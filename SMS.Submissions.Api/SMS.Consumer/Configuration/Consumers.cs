using MassTransit;
using Microsoft.Extensions.Configuration;
using SMS.Consumer.Consumers;

namespace SMS.Consumer.Configuration;

public class Consumers
{
    public static void AddRabbitMq(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator cfg, IConfiguration configuration)
    {
        cfg.ReceiveEndpoint(configuration["MessagesConfiguration:Queues:Grade"], ep =>
        {
            ep.PrefetchCount = 10;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<GradeConsumer>(context);
        });
    }
}