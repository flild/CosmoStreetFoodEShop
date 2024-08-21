using AutoMapper;
using Cosmo.Services.ComboBoxAPI.Models;
using Cosmo.Services.ComboBoxAPI.Models.Dto;

namespace Cosmo.Services.ComboBoxAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration( config =>
            {
                config.CreateMap<ComboDto, Combo>().ReverseMap();
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
