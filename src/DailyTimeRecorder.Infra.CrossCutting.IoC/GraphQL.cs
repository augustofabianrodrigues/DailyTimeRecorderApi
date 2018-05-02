﻿using DailyTimeRecorder.Application.GraphQL;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTimeRecorder.Infra.CrossCutting.IoC
{
    internal static class GraphQL
    {
        internal static void Configure(IServiceCollection services)
        {
            services.AddTransient<DailyTimeRecorderQuery>();
            services.AddTransient<DailyTimeRecorderMutation>();

            services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<ISchema, DailyTimeRecorderSchema>();
        }
    }
}
