using Cosmo.Web.Models;
using Cosmo.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cosmo.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            ResponseDto? responce = await _couponService.GetAllCouponsAsync();
            if (responce != null && responce.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responce.Result));
            }

            return View(list);
        }
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }
    }
}
