using HexagonalAPIWEBWORKER.Core.Domain.Shared;
using HexagonalAPIWEBWORKER.Ports.API.ViewModels.Request;
using HexagonalAPIWEBWORKER.Ports.API.ViewModels.Response;

namespace HexagonalAPIWEBWORKER.Ports.API.Presenters.Interfaces
{
    public interface IBiddingPresenter
    {
        Task<IPaginatedList<GetAllResponseViewModel>> GetAll(GetAllRequestViewModel request);
    }
}
