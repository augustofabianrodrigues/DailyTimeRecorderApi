using DailyTimeRecorder.Application.GraphQL.Interfaces;
using GraphQL.Types;

namespace DailyTimeRecorder.Application.GraphQL
{
    public sealed class DailyTimeRecorderSchema : Schema, IDailyTimeRecorderSchema
    {
        public DailyTimeRecorderSchema(
            IDailyTimeRecorderQuery dailyTimeRecorderQuery,
            IDailyTimeRecorderMutation dailyTimeRecorderMutation)
        {
            Query = dailyTimeRecorderQuery;
            Mutation = dailyTimeRecorderMutation;
        }
    }
}
