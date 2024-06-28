using AutoMapper;
using Cosmo.Services.ProductAPI.Models;
using Cosmo.Services.ProductAPI.Models.Dto;

namespace Cosmo.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration( config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
