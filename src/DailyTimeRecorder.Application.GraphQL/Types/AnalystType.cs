using DailyTimeRecorder.Domain.Models;
using GraphQL.Types;

namespace DailyTimeRecorder.Application.GraphQL.Types
{
    public sealed class AnalystType : ObjectGraphType<Analyst>
    {
        public AnalystType()
        {
            Field(x => x.Id).Description("The id of the analyst.");
            Field(x => x.Name).Description("The name of the analyst.");
            Field(x => x.Email).Description("The e-mail of the analyst.");
        }
    }
}
