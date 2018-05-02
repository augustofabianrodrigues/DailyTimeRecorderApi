using DailyTimeRecorder.Domain.Core.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTimeRecorder.Infra.CrossCutting.IoC
{
    internal static class Events
    {
        internal static void Configure(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
