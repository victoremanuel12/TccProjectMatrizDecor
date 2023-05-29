using Microsoft.AspNetCore.Mvc;
using TccMvc.Repository.Interfaces;
using TccMvc.ViewModel;

namespace TccMvc.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IUnitOfWork _uow;

        public ProdutoController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<IActionResult> List(int categoriaId)
        {
            var produtoViewModel = new ProdutoListViewModel();

            if (categoriaId != 0)
            {
                var categoria = await _uow.CategoriaRepository.Get(c => c.Id == categoriaId);
                var produtos = await _uow.ProdutoRepository.GetAll();
                var produtosFiltrados = produtos.Where(x => x.CategoriaId == categoriaId).ToList();
                produtoViewModel.Produtos = produtosFiltrados;
                produtoViewModel.CategoriaAtual = categoria.Nome;
                produtoViewModel.Categorias = null;
            }
            else
            {
                produtoViewModel.Produtos = await _uow.ProdutoRepository.GetAll();
                produtoViewModel.CategoriaAtual = "Todos os produtos";
            }
            produtoViewModel.Categorias = await _uow.CategoriaRepository.GetAll();

            return View(produtoViewModel);
        }
        public IActionResult Detalhes(int produtoId)
        {
            var detalhesProdutoViewModel = new DetalhesProdutoViewModel();
            detalhesProdutoViewModel.Produto = _uow.ProdutoRepository.GetById(produtoId).Result;
            return View(detalhesProdutoViewModel);
        }


    }
}
