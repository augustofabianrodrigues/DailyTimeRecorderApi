using DailyTimeRecorder.Application.GraphQL.Interfaces;
using GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;

namespace DailyTimeRecorder.Application.GraphQL
{
    public sealed class GraphQLQueryExecuter : IGraphQLQueryExecuter
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLQueryExecuter(
            IDocumentExecuter documentExecuter, IDailyTimeRecorderSchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        public async Task<ExecutionResult> ExecuteAsync(GraphQLQuery query)
        {
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query
            };

            return await _documentExecuter
                .ExecuteAsync(executionOptions)
                .ConfigureAwait(false);
        }
    }
}
