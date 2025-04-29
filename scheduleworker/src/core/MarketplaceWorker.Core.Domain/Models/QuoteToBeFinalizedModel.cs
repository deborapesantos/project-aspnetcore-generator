namespace MarketplaceWorker.Core.Domain.Models
{
    public class QuoteToBeFinalizedModel
    {
        public int QuotationId { get; set; }
        public int QuotationStatusTypeId { get; set; }
        public DateTime DateClosure { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
    }
}
