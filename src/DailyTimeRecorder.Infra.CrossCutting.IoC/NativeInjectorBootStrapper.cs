using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTimeRecorder.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(
            IServiceCollection services, IConfiguration configuration)
        {
            Commands.Configure(services);
            EntityFramework.Configure(services, configuration);
            Events.Configure(services);
            GraphQL.Configure(services);
        }
    }
}
