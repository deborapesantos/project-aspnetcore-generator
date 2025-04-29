using MarketplaceWorker.Core.Domain.Interfaces.Repositories;
using System.Runtime.CompilerServices;

namespace MarketplaceWorker.Core.Application.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationService(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public async Task GetAll()
        {
           
        }
    }
}
