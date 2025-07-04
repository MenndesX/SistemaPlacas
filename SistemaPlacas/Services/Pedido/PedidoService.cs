using Microsoft.EntityFrameworkCore;
using SistemaPlacas.Data;
using SistemaPlacas.Dto.PedidoDto;
using SistemaPlacas.Models;
using System;

namespace SistemaPlacas.Services.Pedido
{
    public class PedidoService : IPedidoInterface
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PedidoModel> AvancarOperacao(int id)
        {
            try
            {
                var pedido = await _context.Pedidos.FindAsync(id);

                pedido.StatusId++;

                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao avançar operação do pedido: {ex.Message}");

            }
        }

        public async Task<List<StatusModel>> BuscarStatus()
        {
            try
            {
                var status = await _context.Status.ToListAsync();

                return status;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar status: {ex.Message}");
            }
        }

        public async Task<PedidoModel> CriarPedido(CriarPedidoDto criarPedidoDto)
        {
            try
            {
                var pedido = new PedidoModel
                {
                    Quantidade = criarPedidoDto.Quantidade,
                    PrecoTotal = criarPedidoDto.PrecoTotal,
                    DataPedido = DateTime.Now,
                    ProdutoId = criarPedidoDto.ProdutoId,
                    ClienteId = criarPedidoDto.ClienteId,
                    StatusId = 1
                };

                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar o pedido: {ex.Message}");
            }
        }

        public async Task<PedidoModel> EditarPedido(int id, EdicaoPedidoDto edicaoPedidoDto)
        {
            try
            {
                var pedido = await _context.Pedidos
                    .Include(p => p.Produto)
                    .FirstOrDefaultAsync(p => p.PedidoId == id);

                if (pedido == null)
                {
                    throw new Exception("Pedido não encontrado.");
                }

                // Se quiser permitir trocar de produto:
                var produto = await _context.Produtos
                    .FirstOrDefaultAsync(p => p.ProdutoId == edicaoPedidoDto.ProdutoId);

                if (produto == null)
                {
                    throw new Exception("Produto não encontrado para o ID informado.");
                }

                pedido.Quantidade = edicaoPedidoDto.Quantidade;
                pedido.PrecoTotal = edicaoPedidoDto.PrecoTotal;

                // Troca o produto
                pedido.ProdutoId = produto.ProdutoId;

                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao editar o pedido: {ex.Message}");
            }
        }

        public async Task<PedidoModel> ExcluirPedido(int id)
        {
            try
            {
                var pedido = await _context.Pedidos.FindAsync(id);
                if (pedido == null)
                {
                    throw new Exception("Pedido não encontrado.");
                }
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir o pedido: {ex.Message}");
            }
        }


        public async Task<List<PedidoModel>> ListarPedido()
        {
            try
            {
                var pedido = await _context.Pedidos
                     .Include(p => p.Cliente)
                     .Include(p => p.Produto)
                     .ToListAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar pedidos: {ex.Message}");
            }
        }
        public async Task<PedidoModel> ObterPedidoPorId(int id)
        {
            try
            {
                var pedido = await _context.Pedidos
                    .Include(p => p.Cliente)
                    .Include(p => p.Produto)
                    .Include(p => p.Status)
                    .FirstOrDefaultAsync(p => p.PedidoId == id);
                if (pedido == null)
                {
                    throw new Exception("Pedido não encontrado.");
                }
                return pedido;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter pedido por ID: {ex.Message}");
            }
        }

        public async Task<PedidoModel> VoltarOperacao(int id)
        {
            try
            {
                var pedido = await _context.Pedidos.FindAsync(id);

                pedido.StatusId--;

                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao voltar operação do pedido: {ex.Message}");
            }
        }
    }
}

