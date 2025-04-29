using MarketplaceWorker.Core.Application.Services;
using Quartz;

namespace MarketplaceWorker.Ports.Worker
{
    public class MarketplaceWorkerJob : IJob
    {
        private readonly IQuotationService _marketplaceWorkerService;
        private readonly ILogger<MarketplaceWorkerJob> _logger;
        public MarketplaceWorkerJob(IQuotationService marketplaceWorkerService,
            ILogger<MarketplaceWorkerJob> logger)
        {
            _marketplaceWorkerService = marketplaceWorkerService;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Executando trabalho em: {DateTime.Now}");
            await _marketplaceWorkerService.GetAll();
        }
    }
}