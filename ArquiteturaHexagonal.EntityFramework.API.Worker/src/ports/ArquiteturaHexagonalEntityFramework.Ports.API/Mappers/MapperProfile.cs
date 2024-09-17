using AutoMapper;
using TemplateHexagonal.Core.Domain.Models;
using TemplateHexagonal.Core.Domain.Shared;
using TemplateHexagonal.Ports.API.ViewModels.Response;

namespace TemplateHexagonal.Ports.API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region GetCommitments

            CreateMap<
                CommitmentItem,
                CommitmentItemResponseViewModel
            >()
            .ForMember(dest => dest.CommitmentAmount, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.CommitmentCode, opt => opt.MapFrom(src => src.Commitment.DocumentCode))
            .ForMember(dest => dest.BiddingNumber, opt => opt.MapFrom(src => src.Commitment.Bidding.DocumentCode))
            .ForMember(dest => dest.BiddingAmount, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.Presentation, opt => opt.MapFrom(src => src.Presentation))
            .ForMember(dest => dest.DateCreate, opt => opt.MapFrom(src => src.Commitment.DateCreate));

            CreateMap<
               PaginatedDataList<CommitmentItem>,
               PaginatedCommitmentsResponseViewModel
           >()
           .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
           .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages))
           .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
            #endregion


            #region Agency
            CreateMap<Agency, AgencyViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            #endregion
        }
    }
}
