using DailyTimeRecorder.Api.Controllers;
using DailyTimeRecorder.Application.GraphQL;
using DailyTimeRecorder.Application.GraphQL.Interfaces;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DailyTimeRecorder.Api.Tests.Unit.Controllers
{
    public class GraphQLControllerShould
    {
        private readonly GraphQLController _graphqlController;

        public GraphQLControllerShould()
        {
            // Given
            var documentExecutor = new Mock<IDocumentExecuter>();
            documentExecutor.Setup(x => x.ExecuteAsync(It.IsAny<ExecutionOptions>())).Returns(Task.FromResult(new ExecutionResult()));
            var schema = new Mock<IDailyTimeRecorderSchema>();
            _graphqlController = new GraphQLController(
                new GraphQLQueryExecuter(documentExecutor.Object, schema.Object)
            );
        }

        [Fact]
        public void ReturnNotNullViewResult()
        {
            // When
            var result = _graphqlController.Index() as ViewResult;

            // Then
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void ReturnNotNullExecutionResult()
        {
            // Given
            var query = new GraphQLQuery { Query = @"{ ""query"": ""query { analysts { id name } }""" };

            // When
            var result = await _graphqlController.Post(query);

            // Then
            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var executionResult = okObjectResult.Value;
            Assert.NotNull(executionResult);
        }
    }
}
