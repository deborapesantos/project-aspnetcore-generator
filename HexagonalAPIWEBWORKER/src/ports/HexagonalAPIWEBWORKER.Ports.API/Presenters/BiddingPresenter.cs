using HexagonalAPIWEBWORKER.Core.Domain.Shared;
using HexagonalAPIWEBWORKER.Ports.API.Presenters.Interfaces;
using HexagonalAPIWEBWORKER.Ports.API.ViewModels.Request;
using HexagonalAPIWEBWORKER.Ports.API.ViewModels.Response;

namespace HexagonalAPIWEBWORKER.Ports.API.Presenters
{
    public class BiddingPresenter : IBiddingPresenter
    {
        public Task<IPaginatedList<GetAllResponseViewModel>> GetAll(GetAllRequestViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
