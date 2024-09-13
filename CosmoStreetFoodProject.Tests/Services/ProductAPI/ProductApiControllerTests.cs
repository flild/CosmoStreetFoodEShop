using Cosmo.Services.ProductAPI.Controllers;
using Cosmo.Services.ProductAPI.Models.Dto;
using Cosmo.Services.ProductAPI.Services;
using FakeItEasy;
using FluentAssertions;

namespace CosmoStreetFoodProject.Tests.Services.ProductAPI
{
    public class ProductApiControllerTests
    {
        private readonly IProductService _productService;
        private readonly ProductAPIController _productController;

        public ProductApiControllerTests()
        {
            _productService = A.Fake<IProductService>();

            //SUT
            _productController = new ProductAPIController(_productService);
        }
        [Fact]
        public void ProductApiController_Get_ReturnSuccess()
        {
            //Arrang
            var products = A.Fake<ResponseDto>();
            A.CallTo(() => _productService.GetAllProducts()).Returns(products);
            //Act
            var result = _productController.Get();
            //Assert
            result.Should().BeOfType<ResponseDto>();
        }
    }
}
