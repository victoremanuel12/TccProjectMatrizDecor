using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;
using TccMvc.Services;
using TccMvc.Utils;
using TccMvc.ViewModel;
using TccMvc.ViewModels;

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
        public async Task<IActionResult> ExcluirItemDoCarrinhoCompra(int produtoId)
        {
            _uow.CarrinhoDeComprasRepository.ExcluirItemDoCarrinho(produtoId, ClienteInSession.GetClienteIdFromSession(HttpContext));
            await _uow.Commit();
            return RedirectToAction("Carrinho", "CarrinhoDeCompras");
        }
        public IActionResult FinalizarCompra()
        {
            var clienteRetornado = _uow.ClienteRepository.GetById(ClienteInSession.GetClienteIdFromSession(HttpContext)).Result;
            var finalizarAluguelViewModel = new FinalizarAluguelViewModel
            {
                Nome = clienteRetornado.Nome,
                Telefone = clienteRetornado.Telefone,
                CEP = clienteRetornado.CEP,
                Bairro = clienteRetornado.Bairro,
                Rua = clienteRetornado.Rua,
                Numero = clienteRetornado.Numero
            };


            //finalizarAluguelViewModel.DataDevolucao = finalizarAluguelViewModel.;
            return View(finalizarAluguelViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FinalizarCompra(FinalizarAluguelViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                if (viewModel != null)
                {

                    var clienteRetornado = _uow.ClienteRepository.GetById(ClienteInSession.GetClienteIdFromSession(HttpContext)).Result;
                    clienteRetornado.Nome = viewModel.Nome;
                    clienteRetornado.Telefone = viewModel.Telefone;
                    clienteRetornado.CEP = viewModel.CEP;
                    clienteRetornado.Bairro = viewModel.Bairro;
                    clienteRetornado.Rua = viewModel.Rua;
                    clienteRetornado.Numero = viewModel.Numero;

                    var listaAluguelProdutos = RegistrarAlugueisProdutos();
                    if(listaAluguelProdutos.Count == 0)
                    {
                        TempData["Error"] = "A quantidade do item no carrinho é maior que no estoque";
                        return RedirectToAction("Carrinho", "CarrinhoDeCompras");
                    }
                    _uow.AluguelRepository.Add(new Aluguel
                    {
                        ClienteId = ClienteInSession.GetClienteIdFromSession(HttpContext),
                        DataEvento = viewModel.DataEvento,
                        DataDevolucao = viewModel.DataEvento.AddDays(2),
                        AluguelProdutos = listaAluguelProdutos,
                    });
                    await _uow.Commit();
                    _uow.CarrinhoDeComprasRepository.ExcluirTodosOsItensDoCarrinho(ClienteInSession.GetClienteIdFromSession(HttpContext));
                    TempData["Success"] = "Aluguel realizado com sucesso, entraremos em contato.";
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    TempData["Error"] = " Preencha todos os campos";
                    return RedirectToAction("FinalizarCompra", "CarrinhoDeCompras");

                }
            }
            return View();

        }



        public List<AluguelProduto> RegistrarAlugueisProdutos()
        {
            var itensCarrinho = _uow.CarrinhoDeComprasRepository.BuscarItensQuantidadeDoCarrinho(ClienteInSession.GetClienteIdFromSession(HttpContext));
            var alugeisProdutos = new List<AluguelProduto>();
            foreach (var item in itensCarrinho)
            {
                if (item.Produto.Quantidade > item.Quantidade)
                {
                    var AluguelProduto = new AluguelProduto
                    {
                        Produto = item.Produto,
                        Quantidade = item.Quantidade
                    };
                    alugeisProdutos.Add(AluguelProduto);
                    item.Produto.Quantidade -= item.Quantidade;

                }
                else
                {
                    return new List<AluguelProduto>();

                }
            }
            return alugeisProdutos;
        }

    }
}
