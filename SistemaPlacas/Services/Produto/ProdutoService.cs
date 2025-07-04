using Microsoft.EntityFrameworkCore;
using SistemaPlacas.Data;
using SistemaPlacas.Dto.Produto;
using SistemaPlacas.Models;

namespace SistemaPlacas.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProdutoModel>> ListarProdutos()
        {
            try
            {
                var produto = await _context.Produtos.AsNoTracking().ToListAsync();
                if (produto == null || !produto.Any())
                {
                    throw new Exception("Nenhum produto encontrado.");
                }
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar produtos: " + ex.Message);
            }
        }

        public async Task<ProdutoModel> CriarProduto(CriarProdutoDto criarProdutoDto)
        {
            try
            {
                var produto = new ProdutoModel
                {
                    Nome = criarProdutoDto.Nome,
                    Descricao = criarProdutoDto.Descricao,
                    Preco = criarProdutoDto.Preco,

                };
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar produto: " + ex.Message);
            }

        }

        public async Task<ProdutoModel> EditarProduto(int id, EditarProdutoDto editarProdutoDto)
        {
            try
            {
                var produto = await  _context.Produtos.FindAsync(id);

                var produtoEditado = new ProdutoModel
                {
                    Nome = editarProdutoDto.Nome,
                    Descricao = editarProdutoDto.Descricao,
                    Preco = editarProdutoDto.Preco,

                };
                _context.Produtos.Update(produtoEditado);
                await _context.SaveChangesAsync();
                return produtoEditado;


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar produto: " + ex.Message);
            }

        }

        public async Task<ProdutoModel> DeletarProduto(int id)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(id);
                if (produto == null)
                {
                    throw new Exception("Produto não encontrado.");
                }
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar produto: " + ex.Message);

            }
        }


    }
}

