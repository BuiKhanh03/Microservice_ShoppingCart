using AutoMapper;
using Tiger.Services.ShoppingCartAPI.Models;
using Tiger.Services.ShoppingCartAPI.Models.Dtos;


namespace Tiger.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            // Create a new MapperConfiguration object and configure it
            var mappingConfig = new MapperConfiguration(config =>
            {
                // Define mappings between CouponDto and Coupon
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            // Return the MapperConfiguration object
            return mappingConfig;
        }
    }
}
