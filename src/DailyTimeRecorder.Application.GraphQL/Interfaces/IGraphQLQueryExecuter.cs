using GraphQL;
using System.Threading.Tasks;

namespace DailyTimeRecorder.Application.GraphQL.Interfaces
{
    public interface IGraphQLQueryExecuter
    {
        Task<ExecutionResult> ExecuteAsync(GraphQLQuery query);
    }
}
