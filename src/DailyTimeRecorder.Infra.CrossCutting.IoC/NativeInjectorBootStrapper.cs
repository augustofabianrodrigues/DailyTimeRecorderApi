using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTimeRecorder.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(
            IServiceCollection services, IConfiguration configuration)
        {
            Application.GraphQL.Configure(services);
            Data.EntityFramework.Configure(services, configuration);
        }
    }
}
