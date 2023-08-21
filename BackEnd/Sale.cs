using System.ComponentModel.DataAnnotations;

namespace HeatMaps
{
    public class Sale
    {
        //independent ID
        [Required]
        public int id { get; set; }
        [Required]
        public string SalesId { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public decimal SumTotal { get { return Amount * Quantity; } }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

    }
}
