using System.ComponentModel.DataAnnotations;

namespace LondonExchange.Data.Entities
{
    public class Exchange
    {
        [Key]
        [MaxLength(5)]
        public string Symbol { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
