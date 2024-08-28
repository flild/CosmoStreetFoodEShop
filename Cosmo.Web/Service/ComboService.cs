using Cosmo.Web.Models;
using Cosmo.Web.Models.Dto;
using Cosmo.Web.Service.IService;
using Cosmo.Web.Utility;

namespace Cosmo.Web.Service
{
    public class ComboService : IComboService
    {
        readonly IBaseService _baseService;
        public ComboService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto?> DeleteComboByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetAllCombos()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/GetCombos",
            });
        }

        public async Task<ResponseDto?> GetAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/GetSelfProduct",
            });
        }

        public async Task<ResponseDto?> GetComboByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/Combo/" + id,
            });
        }

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> PostComboAsync(ComboDto comboDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateComboAsync(ComboDto comboDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateProductsDbAsync()
        {
            throw new NotImplementedException();
        }
    }
}