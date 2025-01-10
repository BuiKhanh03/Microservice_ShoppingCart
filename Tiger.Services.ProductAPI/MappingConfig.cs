using AutoMapper;
using Tiger.Services.ProductAPI.Models;
using Tiger.Services.ProductAPI.Models.Dtos;

namespace Tiger.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            // Create a new MapperConfiguration object and configure it
            var mappingConfig = new MapperConfiguration(config =>
            {
                // Define mappings between CouponDto and Coupon
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            // Return the MapperConfiguration object
            return mappingConfig;
        }
    }
}
