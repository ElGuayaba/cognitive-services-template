using CognitiveServicesTemplate.Application.Contract.Service;
using CognitiveServicesTemplate.Common.ErrorHandling;
using Microsoft.Extensions.Logging;
using OperationResult;
using System.Threading;
using System.Threading.Tasks;
using static OperationResult.Helpers;

namespace CognitiveServicesTemplate.Application.Implementation.Service
{
	public class OcrService : IOcrService
    {
        protected readonly ILogger<OcrService> Logger;

        public OcrService(ILogger<OcrService> logger)
        {
            Logger = logger;
        }

        public async Task<Status<Error>> Create(string userId, CancellationToken cancellationToken = default)
        {
            return Ok();
        }
    }
}