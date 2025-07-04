using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaPlacas.Dto.Cliente;
using SistemaPlacas.Dto.PedidoDto;
using SistemaPlacas.Models;
using SistemaPlacas.Services.Cliente;
using SistemaPlacas.Services.Pedido;
using SistemaPlacas.Services.Produto;

namespace SistemaPlacas.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoInterface _pedidoInterface;
        private readonly IClienteInterface _clienteService;
        private readonly IProdutoInterface _produtoService;



        public PedidoController(IPedidoInterface pedidoInterface, IClienteInterface clienteInterface,
            IProdutoInterface produtoInterface)
        {
            _pedidoInterface = pedidoInterface;
            _clienteService = clienteInterface;
            _produtoService = produtoInterface;



        }
        public async Task<IActionResult> Index()
        {
            var pedido = await _pedidoInterface.ListarPedido();

            var statusList = await _pedidoInterface.BuscarStatus();

            ViewBag.StatusList = statusList;
            return View(pedido);
        }
        [HttpPost]
        public async Task<IActionResult> AvancarEtapa(int pedidoId)
        {
            try
            {
                await _pedidoInterface.AvancarOperacao(pedidoId);
                TempData["Mensagem"] = "Etapa do pedido alterada com sucesso!!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = $"Erro ao avançar operação: {ex.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public async Task<IActionResult> VoltarEtapa(int pedidoId)
        {
            try
            {
                await _pedidoInterface.VoltarOperacao(pedidoId);
                TempData["Mensagem"] = "Etapa do pedido alterada com sucesso!!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = $"Erro ao voltar operação: {ex.Message}";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public async Task<IActionResult> CriarPedido(CriarPedidoDto criarPedidoDto)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Produtos = new SelectList(await _produtoService.ListarProdutos(), "ProdutoId", "Nome");
                ViewBag.Clientes = new SelectList(await _clienteService.ListarClientes(), "ClienteId", "Nome");
                return View(criarPedidoDto);
            }

            var result = await _pedidoInterface.CriarPedido(criarPedidoDto);

            if (result != null)
            {
                TempData["MensagemSucesso"] = "Pedido criado com sucesso!";
                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Erro ao criar pedido.";
            return View(criarPedidoDto);

        }
        [HttpGet]
        public async Task<IActionResult> CriarPedido()
        {
            ViewBag.Produtos = new SelectList(await _produtoService.ListarProdutos(), "ProdutoId", "Nome");
            ViewBag.Clientes = new SelectList(await _clienteService.ListarClientes(), "ClienteId", "Nome");

            return View();
        }
        public async Task<IActionResult> Detalhes(int id)
        {
            var pedido = await _pedidoInterface.ObterPedidoPorId(id);
            if (pedido == null)
            {
                TempData["MensagemErro"] = "Pedido não encontrado.";
                return RedirectToAction("Index");
            }
            ViewBag.Produtos = new SelectList(await _produtoService.ListarProdutos(), "ProdutoId", "Nome");
            return View(pedido);
        }
        public async Task<IActionResult> Editar(EdicaoPedidoDto edicaoPedidoDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Produtos = new SelectList(await _produtoService.ListarProdutos(), "ProdutoId", "Nome");
                ViewBag.Clientes = new SelectList(await _clienteService.ListarClientes(), "ClienteId", "Nome");
                return View(edicaoPedidoDto);
            }

            var pedido = await _pedidoInterface.EditarPedido(edicaoPedidoDto.PedidoId, edicaoPedidoDto);
            if (pedido == null)
            {
                TempData["MensagemErro"] = "Pedido não encontrado.";
                return RedirectToAction("Index");
            }

            TempData["MensagemSucesso"] = "Pedido atualizado com sucesso!";
            return RedirectToAction("Index");
        }




    }

}


