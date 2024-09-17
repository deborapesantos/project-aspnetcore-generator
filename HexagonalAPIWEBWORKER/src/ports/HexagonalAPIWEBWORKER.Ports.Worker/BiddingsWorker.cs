using HexagonalAPIWEBWORKER.Core.Application.Services;

namespace HexagonalAPIWEBWORKER.Ports.Worker
{
    public class BiddingsWorker : BackgroundService
    {
        private readonly IBiddingWorkerService _biddingWorkerService;
        private readonly ILogger<BiddingsWorker> _logger;

        public BiddingsWorker(IBiddingWorkerService biddingWorkerService,
            ILogger<BiddingsWorker> logger)
        {
            _biddingWorkerService = biddingWorkerService;
            _logger = logger; 
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _biddingWorkerService.Process();
                }
                catch (Exception ex)
                {
                    _logger.LogError(string.Format("Error order integration worker: {0}", ex.Message), ex);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
