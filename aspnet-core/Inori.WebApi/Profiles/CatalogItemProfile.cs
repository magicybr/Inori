using AutoMapper;
using Inori.Domain.Models.Catalogs;
using Inori.WebApi.Models;

namespace Inori.WebApi.Profiles
{
    public class CatalogItemProfile : Profile
    {
        public CatalogItemProfile()
        {
            CreateMap<CatalogItem, CatalogItemViewModel>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CatalogBrandCode, opt => opt.MapFrom(src => src.CatalogBrandId))
                .ForMember(dest => dest.CatalogTypeCode, opt => opt.MapFrom(src => src.CatalogTypeId));

        }
    }
}
