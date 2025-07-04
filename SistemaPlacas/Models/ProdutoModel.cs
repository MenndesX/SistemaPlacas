using System.ComponentModel.DataAnnotations;

namespace SistemaPlacas.Models
{
    public class ProdutoModel
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string Nome { get; set; }

        
        public string Descricao { get; set; }
        [Required]
        public decimal Preco { get; set; }
   
        public List<PedidoModel>? Pedidos { get; set; } 


    }
}
