using Cosmo.Services.ComboBoxAPI.Models;
using Cosmo.Services.ComboBoxAPI.Models.Dto;
using System.Diagnostics.CodeAnalysis;

namespace Cosmo.Services.ComboBoxAPI.Utility
{
    public class ProductComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product? x, Product? y)
        {
            if (x is null || x is null)
                return false;
            if (x.ProductId == y.ProductId)
                return true;
            else
                return false;
        }

        public override int GetHashCode([DisallowNull] Product obj)
        {
            return obj.ProductId % 100;
        }
    }
}
