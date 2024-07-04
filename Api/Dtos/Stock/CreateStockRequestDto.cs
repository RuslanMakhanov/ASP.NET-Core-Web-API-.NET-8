using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol Cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Company Name Cannot be over 10 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1,10000000)]
        
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.0001,100)]
        
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength (10, ErrorMessage = "Industry cannot be over 10 characters")]
        public string Industry { get; set; } = string.Empty;
        [Range(1,5000000000)]
        public long MarketCap { get; set; }
    }
}
