using Microsoft.AspNetCore.Mvc;
using SistemaPlacas.Dto.Cliente;
using SistemaPlacas.Services.Cliente;

namespace SistemaPlacas.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet]
        public IActionResult CadastrarCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCliente(CriarClienteDto criarClienteDto)
        {
            if (!ModelState.IsValid)
            {
                return View(criarClienteDto);
            }

            var result = await _clienteInterface.CriarCliente(criarClienteDto);

            if (result != null)
            {
                TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso!";
                return RedirectToAction("Index", "Pedido");
            }

            TempData["MensagemErro"] = "Erro ao cadastrar cliente.";
            return View(criarClienteDto);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteInterface.ListarClientes();
            return View(clientes);
        }
    }
}
