using Newtonsoft.Json;
using Tiger.Services.ShoppingCartAPI.Models.Dtos;
using Tiger.Services.ShoppingCartAPI.Service.IService;

namespace Tiger.Services.ShoppingCartAPI.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CouponService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/coupons/GetByCode/{couponCode}");
            var apiContext = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContext);
            if (resp.IsSuccess)
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp.Result));
            return new CouponDto();
        }
    }
}
