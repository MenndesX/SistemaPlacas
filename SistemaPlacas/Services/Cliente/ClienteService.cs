using Microsoft.EntityFrameworkCore;
using SistemaPlacas.Data;
using SistemaPlacas.Dto.Cliente;
using SistemaPlacas.Models;

namespace SistemaPlacas.Services.Cliente
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteModel>> ListarClientes()
        {
            try
            {
                return await _context.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar clientes: {ex.Message}");
            }
        }

        public async Task<ClienteModel> ObterClientePorId(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);
                if (cliente == null)
                    throw new Exception("Cliente não encontrado.");

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter cliente por id: {ex.Message}");
            }
        }

        public async Task<ClienteModel> CriarCliente(CriarClienteDto criarClienteDto)
        {
            try
            {
                var cliente = new ClienteModel()
                {
                    Nome = criarClienteDto.Nome,
                    Email = criarClienteDto.Email,
                    Telefone = criarClienteDto.Telefone,
                    DataCadastro = DateTime.Now
                };

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar cliente: {ex.Message}");
            }
        }

        public async Task<ClienteModel> EditarCliente(int id, EditarClienteDto editarClienteDto)
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);
                if (cliente == null)
                    throw new Exception("Cliente não encontrado.");

                cliente.Nome = editarClienteDto.Nome;
                cliente.Email = editarClienteDto.Email;
                cliente.Telefone = editarClienteDto.Telefone;
               

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao editar cliente: {ex.Message}");
            }
        }

        public async Task<bool> ExcluirCliente(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                    throw new Exception("Cliente não encontrado.");

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir cliente: {ex.Message}");
            }
        }
    }
}
