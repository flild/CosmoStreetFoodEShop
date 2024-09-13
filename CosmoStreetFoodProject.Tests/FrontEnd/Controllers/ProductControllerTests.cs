using FakeItEasy;
using Cosmo.Web.Service.IService;
using Cosmo.Web.Controllers;
using Cosmo.Web.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CosmoStreetFoodProject.Tests.FrontEnd.Controllers
{
    public class ProductControllerTests
    {
        private readonly IProductService _productService;
        private readonly ProductController _productController;

        public ProductControllerTests()
        {
            _productService = A.Fake<IProductService>();

            //SUT
            _productController = new ProductController(_productService);
        }
        [Fact]
        public void ProductController_ProductIndex_ReturnSuccess()
        {
            //Arrange
            var products = A.Fake<ProductDto>();
            //Act
            var result = _productController.ProductIndex();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
