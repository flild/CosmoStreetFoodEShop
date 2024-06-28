using Cosmo.Web.Models;
using Cosmo.Web.Service.IService;
using Cosmo.Web.Utility;

namespace Cosmo.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/product",
            });
        }

        public async Task<ResponseDto?> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/product/" + id,
            });
        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product",

            });
        }
        //delete this
        public async Task<ResponseDto?> GetProductAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product/GetByCode/" + couponCode,

            });
        }

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product/" + id,

            });
        }

        public async Task<ResponseDto?> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/product/",
            });
        }
    }
}
