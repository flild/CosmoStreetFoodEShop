using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cosmo.Services.ComboBoxAPI.Models.Dto
{
    public class ComboPreviewDto
    {
        public int ComboId { get; set; }
        public string? Name { get; set; }
        public int Discount { get; set; }
    }
}
