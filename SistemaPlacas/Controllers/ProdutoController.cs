using Microsoft.AspNetCore.Mvc;
using SistemaPlacas.Dto.Produto;
using SistemaPlacas.Services.Produto;

namespace SistemaPlacas.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CadastrarProduto(CriarProdutoDto criarProdutoDto)
        {
            var produto = await _produtoInterface.CriarProduto(criarProdutoDto);
            if (produto != null)
            {
                TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                return RedirectToAction("Index", "Pedido");
            }
            TempData["MensagemErro"] = "Erro ao cadastrar produto.";
            return View(criarProdutoDto);

        }
        [HttpGet]
        public IActionResult CadastrarProduto()
        {
            return View();
        }
    }
}
