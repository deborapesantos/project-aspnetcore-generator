using MarketplaceWorker.Core.Domain.Interfaces.Adapters.Repositories;
using MarketplaceWorker.Core.Domain.Models;

namespace MarketplaceWorker.Core.Domain.Interfaces.Repositories
{
    public interface IQuotationRepository : IBaseRepository<QuoteToBeFinalizedModel>
    {
       
    }
}
