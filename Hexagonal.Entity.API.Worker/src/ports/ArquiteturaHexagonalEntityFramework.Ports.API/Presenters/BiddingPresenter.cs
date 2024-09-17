using TemplateHexagonal.Core.Domain.Shared;
using TemplateHexagonal.Ports.API.Presenters.Interfaces;
using TemplateHexagonal.Ports.API.ViewModels.Request;
using TemplateHexagonal.Ports.API.ViewModels.Response;

namespace TemplateHexagonal.Ports.API.Presenters
{
    public class BiddingPresenter : IBiddingPresenter
    {
        public Task<IPaginatedList<GetAllResponseViewModel>> GetAll(GetAllRequestViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
