using DailyTimeRecorder.Application.GraphQL;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTimeRecorder.Infra.CrossCutting.IoC.Application
{
    internal static class GraphQL
    {
        internal static void Configure(IServiceCollection services)
        {
            services.AddTransient<DailyTimeRecorderQuery>();
            services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<ISchema>(
                provider => new Schema { Query = provider.GetService<DailyTimeRecorderQuery>() });
        }
    }
}
