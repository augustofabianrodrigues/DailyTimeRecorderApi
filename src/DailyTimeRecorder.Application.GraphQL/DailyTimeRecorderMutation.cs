using DailyTimeRecorder.Application.GraphQL.Interfaces;
using GraphQL.Types;

namespace DailyTimeRecorder.Application.GraphQL
{
    public sealed class DailyTimeRecorderMutation : ObjectGraphType<object>, IDailyTimeRecorderMutation
    {
    }
}
