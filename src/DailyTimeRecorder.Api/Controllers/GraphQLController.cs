using DailyTimeRecorder.Application.GraphQL;
using DailyTimeRecorder.Application.GraphQL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DailyTimeRecorder.Api.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IGraphQLQueryExecuter _graphQLQueryExecuter;

        public GraphQLController(IGraphQLQueryExecuter graphQLQueryExecuter)
        {
            _graphQLQueryExecuter = graphQLQueryExecuter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await _graphQLQueryExecuter.ExecuteAsync(query);

            if (result.Errors?.Count > 0)
                return BadRequest(result.Errors);

            return Ok(result);
        }
    }
}
