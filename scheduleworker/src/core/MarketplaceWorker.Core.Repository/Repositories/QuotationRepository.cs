using MarketplaceWorker.Adapters.Repository.Context;
using MarketplaceWorker.Core.Domain.Interfaces.Repositories;
using MarketplaceWorker.Core.Domain.Models;

namespace MarketplaceWorker.Core.Repository.Repositories
{
    public class QuotationRepository : BaseRepository<QuoteToBeFinalizedModel>, IQuotationRepository
    {
        public QuotationRepository(MarketplaceWorkerDBContext context) : base(context)
        {
        }
    }
}
