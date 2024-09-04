using Cosmo.Web.Models;
using Cosmo.Web.Models.Dto;
using Cosmo.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cosmo.Web.Controllers
{
    public class ComboController : Controller
    {
        private readonly IComboService _comboService;

        public ComboController(IComboService comboService)
        {
            _comboService = comboService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ComboIndex()
        {
            List<ComboDto>? list = new();

            ResponseDto? response = await _comboService.GetAllCombosAsync();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ComboDto>>(Convert.ToString(response.Result));

            }
            else
            {
                TempData["error"] = response?.Result;
            }
            return View(list);
        }

        public async Task<IActionResult> CreateCombo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCombo(ComboDto comboDto)
        {
            ResponseDto response = await _comboService.PostComboAsync(comboDto);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "combo created successfully";
            }
            else
            {
                TempData["error"] = response?.Result;
            }
            return View(comboDto);
        }

        public async Task<IActionResult> ComboDelete(int CouponID)
        {
            ResponseDto? responce = await _comboService.GetComboByIdAsync(CouponID);
            if (responce != null && responce.IsSuccess)
            {
                ComboDto? model = JsonConvert.DeserializeObject<ComboDto>(Convert.ToString(responce.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = responce?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ComboDelete(ComboDto comboDto)
        {
            ResponseDto? responce = await _comboService.DeleteComboByIdAsync(comboDto.ComboId);
            if (responce != null && responce.IsSuccess)
            {
                TempData["success"] = "Combo deleted successfully";
                return RedirectToAction(nameof(ComboIndex));
            }
            else
            {
                TempData["error"] = responce?.Message;
            }
            return View(comboDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductList()
        {
            ResponseDto? responce = await _comboService.UpdateProductsDbAsync();
            if(responce == null || !responce.IsSuccess)
            { 
                TempData["error"] = responce?.Message;
            }
            return View();
        }
    }
}
