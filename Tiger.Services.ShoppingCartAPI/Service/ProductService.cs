using Newtonsoft.Json;
using Tiger.Services.ShoppingCartAPI.Models.Dtos;
using Tiger.Services.ShoppingCartAPI.Service.IService;

namespace Tiger.Services.ShoppingCartAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/products");
            var apiContext = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContext);
            if (resp.IsSuccess)
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));
            return new List<ProductDto>();
        }
    }
}
