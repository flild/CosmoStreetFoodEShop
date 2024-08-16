using AutoMapper;
using Cosmo.Services.ComboBoxAPI.Data;
using Cosmo.Services.ComboBoxAPI.Models;
using Cosmo.Services.ComboBoxAPI.Models.Dto;
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
        private IMapper _mapper; 

        public ComboBoxController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet("UpdateProducts")]
        public async Task<ResponseDto> UpdateProductsDb()
        {
            //логика запроса продуктов из апи продуктов
            return _response;
        }
        [HttpGet("GetCombos")]
        public async Task<ResponseDto>GetComos()
        {
            try
            {
                IEnumerable<Combo> combos = _db.Combos.ToList();
                _response.Result = _mapper.Map<IEnumerable<Combo>>(combos);
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
