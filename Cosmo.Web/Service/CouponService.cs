using Cosmo.Web.Models;
using Cosmo.Web.Service.IService;

namespace Cosmo.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetAllCouponsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
