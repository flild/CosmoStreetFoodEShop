using AutoMapper;
using Azure;
using Cosmo.Services.ProductAPI.Data;
using Cosmo.Services.ProductAPI.Models;
using Cosmo.Services.ProductAPI.Models.Dto;

namespace Cosmo.Services.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private ResponseDto _response;

        public ProductService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        public ResponseDto CreateProduct(ProductDto productDto)
        {
            try
            {
                Product coupon = _mapper.Map<Product>(productDto);
                _db.Products.Add(coupon);
                _db.SaveChanges();
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public ResponseDto DeleteProduct(int id)
        {
            try
            {
                Product product = _db.Products.First(c => c.ProductId == id);
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public ResponseDto GetAllProducts()
        {
            try
            {
                IEnumerable<Product> products = _db.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<Product>>(products);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public ResponseDto GetProductById(int id)
        {
            try
            {
                Product product = _db.Products.First(c => c.ProductId == id);
                _response.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public ResponseDto UpdateProduct(ProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);
                _db.Products.Update(product);
                _db.SaveChanges();
                _response.Result = productDto;
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
