using HotChocolate.AzureFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CourseProvider.Functions;

public class GraphQL(ILogger<GraphQL> logger, IGraphQLRequestExecutor executor)
{
    private readonly ILogger<GraphQL> _logger = logger;
    private readonly IGraphQLRequestExecutor _executor = executor;

    [Function("GraphQL")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route ="graphql")] HttpRequest req)
    {
        try
        {
            return await _executor.ExecuteAsync(req);
        }
        catch (Exception ex)
        {
            _logger.LogError($"ERROR : GraphQl.Run() :: {ex.Message}");
            return new StatusCodeResult(500);
        }
    }
}
