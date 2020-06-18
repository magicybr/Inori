using AutoMapper;
using Inori.Domain.Models.Catalogs;
using Inori.WebApi.Models;

namespace Inori.WebApi.Profiles
{
    public class CatalogTypeProfile : Profile
    {
        public CatalogTypeProfile()
        {
            CreateMap<CatalogType, CatalogTypeViewModel>()
                .ForMember(dest => dest.CatalogTypeCode, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CatalogTypeName, opt => opt.MapFrom(src => src.Type));
        }
    }
}
