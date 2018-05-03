using DailyTimeRecorder.Application.GraphQL;
using DailyTimeRecorder.Application.GraphQL.Interfaces;
using DailyTimeRecorder.Domain.Core.Interfaces;
using DailyTimeRecorder.Domain.Core.Notifications;
using DailyTimeRecorder.Domain.Interfaces;
using DailyTimeRecorder.Infra.Data.EntityFramework.Context;
using DailyTimeRecorder.Infra.Data.EntityFramework.Repository;
using GraphQL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTimeRecorder.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(
            IServiceCollection services, IConfiguration configuration)
        {
            // EntityFramework
            services.AddDbContext<DailyTimeRecorderContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IDbContext, DailyTimeRecorderContext>();
            services.AddTransient<IAnalystRepository, AnalystRepository>();

            // Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // GraphQL
            services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<IDailyTimeRecorderMutation, DailyTimeRecorderMutation>();
            services.AddTransient<IDailyTimeRecorderQuery, DailyTimeRecorderQuery>();
            services.AddTransient<IDailyTimeRecorderSchema, DailyTimeRecorderSchema>();
            services.AddTransient<IGraphQLQueryExecuter, GraphQLQueryExecuter>();
        }
    }
}
