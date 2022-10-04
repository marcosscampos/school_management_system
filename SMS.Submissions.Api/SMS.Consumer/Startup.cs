using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Consumer.Extensions;
using SMS.Consumer.Workers;
using SMS.Submissions.Api.Common.DI;

namespace SMS.Consumer;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureConsumerApplicationDependencies(Configuration);
        services.ConfigureApplicationDependencies(Configuration);
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();
    }
}