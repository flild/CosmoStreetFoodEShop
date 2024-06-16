using AutoMapper;
using Cosmo.Services.CouponAPI.Models;
using Cosmo.Services.CouponAPI.Models.Dto;

namespace Cosmo.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration( config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<PostCouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
