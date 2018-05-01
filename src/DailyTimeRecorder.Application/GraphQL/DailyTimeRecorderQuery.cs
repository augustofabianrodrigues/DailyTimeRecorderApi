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
                resolve: context => analystRepository.Get(1)
            );
        }
    }
}
