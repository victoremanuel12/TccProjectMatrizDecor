using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TccMvc.Autorizacao;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;
using TccMvc.Services;
using TccMvc.ViewModel;

namespace TccMvc.Controllers
{
    public class CarrinhoDeComprasController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CarrinhoDeComprasController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        [AutorizacaoFiltro]
        public IActionResult Carrinho()
        {
            var ProdutosCarrinhoViewModel = new ProdutosCarrinhoViewModel();
            ProdutosCarrinhoViewModel.CarrinhoDeComprasItems = _uow.CarrinhoDeComprasRepository.BuscarItensQuantidadeDoCarrinho(ClienteInSession.GetClienteIdFromSession(HttpContext));
            ProdutosCarrinhoViewModel.ValorTotalCarrinhoCompra = _uow.CarrinhoDeComprasRepository.CarrinhoCompraTotal(ClienteInSession.GetClienteIdFromSession(HttpContext));

            return View(ProdutosCarrinhoViewModel);
        }

        [AutorizacaoFiltro]
        public async Task<IActionResult> AdicionarItemAoCarrinhoCompra(int produtoId)
        {

            _uow.CarrinhoDeComprasRepository.AdiconarItemAoCarrinho(produtoId, ClienteInSession.GetClienteIdFromSession(HttpContext));
            await _uow.Commit();
            return RedirectToAction("Carrinho", "CarrinhoDeCompras");
        }
        public async Task< IActionResult> ExcluirItemDoCarrinhoCompra(int produtoId)
        {
            _uow.CarrinhoDeComprasRepository.ExcluirItemDoCarrinho(produtoId, ClienteInSession.GetClienteIdFromSession(HttpContext));
            await _uow.Commit();
            return RedirectToAction("Carrinho", "CarrinhoDeCompras");
        }
        public IActionResult FinalizarCompra()
        {
            var clienteRetornado = _uow.ClienteRepository.GetById(ClienteInSession.GetClienteIdFromSession(HttpContext)).Result;

            return View(clienteRetornado);
        }

        [HttpPost]
        public async Task<IActionResult> FinalizarCompra(Cliente cliente, DateTime dataInicio, DateTime dataFinal)
        {
            if(cliente is not null)
            {
                var clienteRetornado = _uow.ClienteRepository.GetById(ClienteInSession.GetClienteIdFromSession(HttpContext)).Result;
                clienteRetornado.Nome = cliente.Nome;
                clienteRetornado.Telefone = cliente.Telefone;
                clienteRetornado.CEP = cliente.CEP;
                clienteRetornado.Bairro = cliente.Bairro;
                clienteRetornado.Rua = cliente.Rua;
                clienteRetornado.Numero = cliente.Numero;

                var listaAluguelProdutos = RegistrarAlugueisProdutos();
                _uow.AluguelRepository.Add(new Aluguel
                {
                    ClienteId = ClienteInSession.GetClienteIdFromSession(HttpContext),
                    DataInicio = dataInicio,
                    DataFinal = dataFinal,
                    AluguelProdutos = listaAluguelProdutos,
                });
            }
           
            await _uow.Commit();
            _uow.CarrinhoDeComprasRepository.ExcluirTodosOsItensDoCarrinho(ClienteInSession.GetClienteIdFromSession(HttpContext));
            return RedirectToAction("List", "Produto");
        }
        public List<AluguelProduto> RegistrarAlugueisProdutos()
        {
            var itensCarrinho = _uow.CarrinhoDeComprasRepository.BuscarItensQuantidadeDoCarrinho(ClienteInSession.GetClienteIdFromSession(HttpContext));
            var alugeisProdutos = new List<AluguelProduto>();
            foreach (var item in itensCarrinho)
            {
                var AluguelProdutos = new AluguelProduto
                {
                  Produto = item.Produto
                };
                alugeisProdutos.Add(AluguelProdutos);
            }
            return alugeisProdutos;
        }

    }
}
