using Cosmo.Services.ComboBoxAPI.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cosmo.Services.ComboBoxAPI.Models
{
    public class Combo
    {
        [Key]
        public int ComboId { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
