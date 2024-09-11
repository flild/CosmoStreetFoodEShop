using Cosmo.Services.ProductAPI.Models;
using Cosmo.Services.ProductAPI.Models.Dto;
namespace Cosmo.Services.ProductAPI.Services
{
    public interface IProductService
    {
        public ResponseDto GetAllProducts();
        public ResponseDto GetProductById(int id);
        public ResponseDto CreateProduct(ProductDto product);
        public ResponseDto UpdateProduct(ProductDto product);
        public ResponseDto DeleteProduct(int id);
    }
}
