using DailyTimeRecorder.Domain.Core.Interfaces;
using DailyTimeRecorder.Domain.Interfaces;
using DailyTimeRecorder.Infra.Data.EntityFramework.Context;
using DailyTimeRecorder.Infra.Data.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTimeRecorder.Infra.CrossCutting.IoC.Data
{
    internal static class EntityFramework
    {
        internal static void Configure(
            IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DailyTimeRecorderContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));

            services.AddTransient<IDbContext, DailyTimeRecorderContext>();
            services.AddTransient<IAnalystRepository, AnalystRepository>();
        }
    }
}
