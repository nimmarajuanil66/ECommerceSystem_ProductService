using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductService.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            // 🔹 Log Request
            _logger.LogInformation("Handling {RequestName} with data: {@Request}",
                requestName,
                JsonSerializer.Serialize(request));

            var stopwatch = Stopwatch.StartNew();

            var response = await next();

            stopwatch.Stop();

            // 🔹 Log Response
            _logger.LogInformation("Handled {RequestName} in {ElapsedMilliseconds}ms. Response: {@Response}",
                requestName,
                stopwatch.ElapsedMilliseconds,
                JsonSerializer.Serialize(response));

            return response;
        }
    }
}
