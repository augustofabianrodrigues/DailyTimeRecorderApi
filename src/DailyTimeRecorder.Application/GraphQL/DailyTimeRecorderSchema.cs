using GraphQL.Types;

namespace DailyTimeRecorder.Application.GraphQL
{
    public sealed class DailyTimeRecorderSchema : Schema
    {
        public DailyTimeRecorderSchema(
            DailyTimeRecorderQuery dailyTimeRecorderQuery,
            DailyTimeRecorderMutation dailyTimeRecorderMutation)
        {
            Query = dailyTimeRecorderQuery;
            Mutation = dailyTimeRecorderMutation;
        }
    }
}
