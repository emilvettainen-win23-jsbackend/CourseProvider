using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CourseProvider.Functions;

public class PlayGround(ILogger<PlayGround> logger)
{
    private readonly ILogger<PlayGround> _logger = logger;

    [Function("PlayGround")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route ="playground")] HttpRequestData req)
    {
        try
        {
            var response = req.CreateResponse();
            response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            await response.WriteStringAsync(PlaygroundPage());
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError($"ERROR : PlayGround.Run() :: {ex.Message}");
            return null!;
        }
    }

    private string PlaygroundPage()
    {
        return @"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset=""utf-8""/>
            <title>GraphQL Playground</title>
            <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/graphql-playground-react/build/static/css/index.css""/>
            <link rel=""shortcut icon"" href=""https://cdn.jsdelivr.net/npm/graphql-playground-react/build/favicon.png"" />
            <script src=""https://cdn.jsdelivr.net/npm/graphql-playground-react/build/static/js/middleware.js""></script>
        </head>
        <body>
            <div id=""root""></div>
            <script>
                window.addEventListener('load', function (event) {
                    const root = document.getElementById('root');
                    GraphQLPlayground.init(root, {
                        endpoint: '/api/graphql'
                    })
                });
            </script>
        </body>
        </html>";
    }
}