using AutoMapper;
using Cosmo.Services.ComboBoxAPI.Data;
using Cosmo.Services.ComboBoxAPI.Models;
using Cosmo.Services.ComboBoxAPI.Models.Dto;
using Cosmo.Services.ComboBoxAPI.Service.IService;
using Cosmo.Services.ComboBoxAPI.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmo.Services.ComboBoxAPI.Controllers
{
    [Route("api/combobox")]
    [ApiController]
    public class ComboBoxController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IProductService _productService;
        private IMapper _mapper; 

        public ComboBoxController(AppDbContext db, IMapper mapper, IProductService productService)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
            _productService = productService;
        }

        [HttpGet("UpdateProducts")]
        public async Task<ResponseDto> UpdateProductsDb()
        {
            IEnumerable<Product> productsMain = _mapper.Map<IEnumerable<Product>>(await _productService.GetProducts());
            IEnumerable<Product> productsCopy = _db.Products.ToList();
            var newProductList = productsMain.Except(productsCopy, new ProductComparer()).ToList();
            var toDeleteProductList = productsCopy.Except(productsMain, new ProductComparer()).ToList();

            //
            foreach ( Product product in toDeleteProductList)
            {
                _db.Products.Remove(product);
            }
            //
            foreach (Product product in newProductList)
            {
                _db.Products.Add(product);
            }
            _db.SaveChanges();
            return _response;
        }

        [HttpGet("GetSelfProduct")]
        public async Task<ResponseDto> GetSelfProducts()
        {
            try
            {
                IEnumerable<Product> combos = _db.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<Product>>(combos);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet("GetCombos")]
        public async Task<ResponseDto> GetCombos()
        {
            try
            {
                IEnumerable<Combo> combos = _db.Combos.ToList();
                _response.Result = _mapper.Map<IEnumerable<ComboDto>>(combos);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("Combo/{id}")]
        public async Task<ResponseDto> GetComboById(int id)
        {
            try
            {
                Combo combo = _db.Combos.First(c => c.ComboId == id);
                _response.Result = _mapper.Map<ComboDto>(combo);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
            
        }
        [HttpPost]
        [Route("PostCombo")]
        public ResponseDto PostCombo([FromBody] ComboDto comboDto)
        {
            try
            {
                Combo combo = _mapper.Map<Combo>(comboDto);
                _db.Combos.Add(combo);
                _db.SaveChanges();
                _response.Result = comboDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost]
        [Route("UpdateCombo")]
        public ResponseDto UpdateCombo([FromBody] ComboDto comboDto)
        {
            try
            {
                _db.Combos.Update(_mapper.Map<Combo>(comboDto));
                _db.SaveChanges();
                _response.Result = comboDto;
            }
            catch (Exception ex)
            { 
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("DeleteCombo/{id}")]
        public ResponseDto DeleteCombo(int id) 
        {
            try
            {
                Combo combo = _db.Combos.First(c => c.ComboId == id);
                _db.Combos.Remove(combo);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return _response;
        }

    }
}
