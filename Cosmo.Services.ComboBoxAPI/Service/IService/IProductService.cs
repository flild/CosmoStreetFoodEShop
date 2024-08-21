using Cosmo.Services.ComboBoxAPI.Models.Dto;
using System.Collections;

namespace Cosmo.Services.ComboBoxAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
