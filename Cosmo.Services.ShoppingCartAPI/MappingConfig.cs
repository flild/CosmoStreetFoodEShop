using AutoMapper;
using Cosmo.Services.ShoppingCartAPI.Models;
using Cosmo.Services.ShoppingCartAPI.Models.Dto;

namespace Cosmo.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration( config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
