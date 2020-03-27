using System.ComponentModel.DataAnnotations;

namespace ASPNetCore_API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        [Range(minimum: 0.00, maximum: (double) decimal.MaxValue)]
        public float Preco { get; set; }
    }
}
