using SistemaPlacas.Dto.Cliente;
using SistemaPlacas.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaPlacas.Services.Cliente
{
    public interface IClienteInterface
    {
        Task<List<ClienteModel>> ListarClientes();
        Task<ClienteModel> ObterClientePorId(int id);
        Task<ClienteModel> CriarCliente(CriarClienteDto cliente);
        Task<ClienteModel> EditarCliente(int id, EditarClienteDto editarClienteDto);
        Task<bool> ExcluirCliente(int id);
    }
}
