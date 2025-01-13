using Tiger.Services.ShoppingCartAPI.Models.Dtos;

namespace Tiger.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
