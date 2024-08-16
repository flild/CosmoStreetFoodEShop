using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cosmo.Services.ComboBoxAPI.Models.Dto
{
    public class ComboDto
    {
        public int ComboId { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
