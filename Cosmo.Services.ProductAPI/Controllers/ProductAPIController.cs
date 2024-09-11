using AutoMapper;
using Cosmo.Services.ProductAPI.Data;
using Cosmo.Services.ProductAPI.Models;
using Cosmo.Services.ProductAPI.Models.Dto;
using Cosmo.Services.ProductAPI.Services;
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
        private ResponseDto _response;
        private IProductService _productService;
        public ProductAPIController(IProductService productService)
        {
            _productService = productService;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            return _productService.GetAllProducts();
        }
        [HttpGet("{id}")]
        public ResponseDto Get(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] ProductDto productPostDto)
        {
            return _productService.CreateProduct(productPostDto);
        }
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ProductDto productDto)
        {
            return _productService.UpdateProduct(productDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            return _productService.DeleteProduct(id);
        }
    }
}
