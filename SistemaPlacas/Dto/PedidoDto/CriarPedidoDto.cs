using SistemaPlacas.Dto.Cliente;
using SistemaPlacas.Models;


namespace SistemaPlacas.Dto.PedidoDto
{
    public class CriarPedidoDto
    {
        public int Quantidade { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }

        public int ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }

    }
}
