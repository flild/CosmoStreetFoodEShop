using Cosmo.Services.ComboBoxAPI.Models.Dto;
using Cosmo.Services.ComboBoxAPI.Service.IService;
using Newtonsoft.Json;

namespace Cosmo.Services.ComboBoxAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {

            var client = _httpClientFactory.CreateClient("Product");
            var responce = await client.GetAsync($"/api/product");
            var apiContent = await responce.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if(resp.IsSuccess) 
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));
            }
            return new List<ProductDto>();
        }
    }
}
