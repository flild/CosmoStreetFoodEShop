using Cosmo.Services.ShoppingCartAPI.Models.Dto;
using System.Collections;

namespace Cosmo.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
