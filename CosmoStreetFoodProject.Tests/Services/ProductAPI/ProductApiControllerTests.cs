using Cosmo.Services.ProductAPI.Services;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmoStreetFoodProject.Tests.Services.ProductAPI
{
    internal class ProductApiControllerTests
    {
        private readonly IProductService _productService;

        public ProductApiControllerTests()
        {
            _productService = A.Fake<IProductService>();
        }
    }
}
