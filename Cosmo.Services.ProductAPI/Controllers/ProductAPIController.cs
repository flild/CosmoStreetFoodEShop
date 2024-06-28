using AutoMapper;
using Cosmo.Services.ProductAPI.Data;
using Cosmo.Services.ProductAPI.Models;
using Cosmo.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Cosmo.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public ProductAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Product> coupons = _db.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<Product>>(coupons);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet("{id}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Product coupon = _db.Products.First(c => c.ProductId ==  id);
                _response.Result = _mapper.Map<ProductDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] ProductDto couponPostDto)
        {
            try
            {
                Product coupon = _mapper.Map<Product>(couponPostDto);
                _db.Products.Add(coupon);
                _db.SaveChanges();
                _response.Result = couponPostDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ProductDto couponDto)
        {
            try
            {
                Product coupon = _mapper.Map<Product>(couponDto);
                _db.Products.Update(coupon);
                _db.SaveChanges();
                _response.Result = couponDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product coupon = _db.Products.First(c => c.ProductId == id);
                _db.Products.Remove(coupon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
