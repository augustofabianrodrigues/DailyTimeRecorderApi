using DailyTimeRecorder.Domain.Interfaces;
using GraphQL.Types;

namespace DailyTimeRecorder.Application.GraphQL
{
    public sealed class DailyTimeRecorderQuery : ObjectGraphType
    {
        public DailyTimeRecorderQuery(IAnalystRepository analystRepository)
        {
            Field<AnalystType>(
                "analyst",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                ),
                resolve: context =>
                    analystRepository.GetAsync(context.GetArgument<long>("id"))
            );

            Field<ListGraphType<AnalystType>>(
                "analysts",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name" },
                    new QueryArgument<StringGraphType> { Name = "email" }
                ),
                resolve: context =>
                    analystRepository.GetOptionallyByNameAndEmail(
                        context.GetArgument<string>("name"), context.GetArgument<string>("email"))
            );
        }
    }
}
