using TemplateHexagonal.Core.Domain.Shared;
using TemplateHexagonal.Ports.API.ViewModels.Request;
using TemplateHexagonal.Ports.API.ViewModels.Response;

namespace TemplateHexagonal.Ports.API.Presenters.Interfaces
{
    public interface IBiddingPresenter
    {
        Task<IPaginatedList<GetAllResponseViewModel>> GetAll(GetAllRequestViewModel request);
    }
}
