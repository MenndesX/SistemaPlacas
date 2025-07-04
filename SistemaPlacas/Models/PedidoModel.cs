using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPlacas.Models
{
    public class PedidoModel
    {
        [Key]
        public int PedidoId { get; set; }
        
        public int Quantidade { get; set; }
       
        public decimal PrecoTotal { get; set; }
        [Required]
        public DateTime DataPedido { get; set; } = DateTime.Now;

        public int ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }

        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }
        public int StatusId { get; set; }   
        public StatusModel Status { get; set; }
    }
}
