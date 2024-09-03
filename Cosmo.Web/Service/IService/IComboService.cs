using Cosmo.Web.Models;
using Cosmo.Web.Models.Dto;

namespace Cosmo.Web.Service.IService
{
    public interface IComboService
    {
        Task<ResponseDto?> GetAllProductAsync();
        Task<ResponseDto?> GetComboByIdAsync(int id);
        Task<ResponseDto?> GetAllCombosAsync();
        Task<ResponseDto?> UpdateProductsDbAsync();
        Task<ResponseDto?> PostComboAsync(ComboDto comboDto);
        Task<ResponseDto?> UpdateComboAsync(ComboDto comboDto);
        Task<ResponseDto?> DeleteComboByIdAsync(int id);

    }
}