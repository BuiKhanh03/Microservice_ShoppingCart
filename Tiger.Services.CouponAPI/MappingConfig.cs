using AutoMapper;
using Tiger.Services.CouponAPI.Models;
using Tiger.Services.CouponAPI.Models.Dtos;

namespace Tiger.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            // Create a new MapperConfiguration object and configure it
            var mappingConfig = new MapperConfiguration(config =>
            {
                // Define mappings between CouponDto and Coupon
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            // Return the MapperConfiguration object
            return mappingConfig;
        }
    }
}
