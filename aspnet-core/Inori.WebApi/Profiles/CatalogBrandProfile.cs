using AutoMapper;
using Inori.Domain.Models.Catalogs;
using Inori.WebApi.Models;

namespace Inori.WebApi.Profiles
{
    public class CatalogBrandProfile : Profile
    {
        public CatalogBrandProfile()
        {
            CreateMap<CatalogBrand, CatalogBrandViewModel>()
                .ForMember(dest => dest.CatalogBrandCode, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CatalogBrandName, opt => opt.MapFrom(src => src.Brand));
        }
    }
}
