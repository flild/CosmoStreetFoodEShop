namespace Cosmo.Services.CouponAPI.Models.Dto
{
    public class PostCouponDto
    {
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
