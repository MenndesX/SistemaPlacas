

namespace SistemaPlacas.Dto.PedidoDto
{
    public class EdicaoPedidoDto
    {  
        public int PedidoId { get; set; }
        public int Quantidade { get; set; }

        public decimal PrecoTotal { get; set; }
        public int ProdutoId { get; set; }


    }
}
