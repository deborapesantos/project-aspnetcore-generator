namespace MarketplaceWorker.Core.Domain.Enum
{
    public enum QuotationStatusEnum
    {
        InProgress = 1,         //Em Andamento
        Quoted = 2,	            //Cotado"
        AwaitingApproval = 3,   //Aguardando aprovação"
        Cancelled = 4,	        //Cancelado"
        Archived = 5,	        //Arquivado"
        AwaitingRelease = 6	    //Aguardando Lançamento"
    }
}
