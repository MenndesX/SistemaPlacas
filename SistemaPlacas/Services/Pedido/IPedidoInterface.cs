using SistemaPlacas.Dto.PedidoDto;
using SistemaPlacas.Models;

namespace SistemaPlacas.Services.Pedido
{
    public interface IPedidoInterface
    {
        Task<List<PedidoModel>> ListarPedido();
        Task<PedidoModel> ObterPedidoPorId(int id);
        Task<PedidoModel> CriarPedido(CriarPedidoDto criarPedidoDto);
        Task<PedidoModel> EditarPedido(int id, EdicaoPedidoDto edicaoPedidoDto);
        Task<PedidoModel>ExcluirPedido(int id);
        Task<List<StatusModel>> BuscarStatus();
        Task<PedidoModel>AvancarOperacao(int id);

        Task<PedidoModel>VoltarOperacao(int id);

    }
}
