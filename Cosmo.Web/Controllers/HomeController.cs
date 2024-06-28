using Cosmo.Web.Models;
using Cosmo.Web.Service.IService;
using Cosmo.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Cosmo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto>? list = new();

            ResponseDto? responce = await _productService.GetAllProductsAsync();
            if (responce != null && responce.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responce.Result));
            }
            else
            {
                TempData["error"] = responce?.Message;
            }

            return View(list);
        }
        [Authorize]
        public async Task<IActionResult> ProductDetails(int productID)
        {
            ProductDto? model = new();

            ResponseDto? responce = await _productService.GetProductByIdAsync(productID);
            if (responce != null && responce.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responce.Result));
            }
            else
            {
                TempData["error"] = responce?.Message;
            }

            return View(model);
        }

        [Authorize(Roles = SD.RoleAdmin)]   
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
