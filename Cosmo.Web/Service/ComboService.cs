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

        public async Task<ResponseDto?> DeleteComboByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/DeleteCombo" + id,
            });
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


        public async Task<ResponseDto?> PostComboAsync(ComboDto comboDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.POST,
                Data = comboDto,
                Url = SD.ProductAPIBase + "/api/PostCombo",
            });
        }

        public async Task<ResponseDto?> UpdateComboAsync(ComboDto comboDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.POST,
                Data = comboDto,
                Url = SD.ProductAPIBase + "/api/UpdateCombo",
            });
        }

        public async Task<ResponseDto?> UpdateProductsDbAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/UpdateProducts",
            });
        }
    }
}