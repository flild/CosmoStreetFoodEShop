﻿using Cosmo.Web.Models;
using Cosmo.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        [HttpPost]
		public async Task<IActionResult> CouponCreate(CouponDto model)
		{
            if (ModelState.IsValid)
            {
				ResponseDto? responce = await _couponService.CreateCouponAsync(model);
				if (responce != null && responce.IsSuccess)
				{
					return RedirectToAction("Index", "Home");
				}
			}
			return View(model);
		}

		public async Task<IActionResult> CouponDelete(int CouponID)
		{
			ResponseDto? responce = await _couponService.GetCouponByIdAsync(CouponID);
			if (responce != null && responce.IsSuccess)
			{
				CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responce.Result));
                return View(model);
			}
			return NotFound();
		}
	}
}