using TemplateHexagonal.Core.Domain.Models;
using TemplateHexagonal.Core.Domain.Shared;
using TemplateHexagonal.Ports.API.ViewModels.Response;

namespace TemplateHexagonal.Ports.API.Presenters.Interfaces
{
    public interface ICommitmentPresenter
    {
        Task<PaginatedCommitmentsResponseViewModel> GetCommitments(int index, int size, int? portalSearchId, DateTime? startDate, DateTime? endDate, string? presentation);
        Task<List<AgencyViewModel>> GetFilters();
    }
}
