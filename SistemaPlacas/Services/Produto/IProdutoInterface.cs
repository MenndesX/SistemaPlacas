using SistemaPlacas.Dto.Produto;
using SistemaPlacas.Models;

namespace SistemaPlacas.Services.Produto
{
    public interface IProdutoInterface 
    {
        Task<List<ProdutoModel>> ListarProdutos();
        Task<ProdutoModel>CriarProduto(CriarProdutoDto criarProdutoDto);
        Task<ProdutoModel>EditarProduto(int id, EditarProdutoDto editarProdutoDto);
        Task<ProdutoModel>DeletarProduto(int id);


    }
}
