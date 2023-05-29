using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;

namespace TccMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CategoriasController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _uow.CategoriaRepository.GetAll();
            return View(categorias);
        }

        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _uow.CategoriaRepository.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _uow.CategoriaRepository.Add(categoria);
                await _uow.Commit();
            }
            return RedirectToAction("Index", "Categorias");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _uow.CategoriaRepository.GetById(id);
            if (categoria is null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    var categoriaRetornada = await _uow.CategoriaRepository.GetById(id);
                    if (categoriaRetornada == null)
                    {
                        return NotFound();
                    }

                    categoriaRetornada.Nome = categoria.Nome;
                    categoriaRetornada.Descricao = categoria.Descricao;
                    _uow.CategoriaRepository.Update(categoriaRetornada);
                    await _uow.Commit();

                    return RedirectToAction(nameof(Index));
              
            }
            return View(categoria);
        }

        public async Task<IActionResult> Delete(int id)
        {
           Categoria categoria = await _uow.CategoriaRepository.GetById(id);
           TempData["MensagemSucesso"] = "Categoria carregada com sucesso.";
            if (categoria == null)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao carregar a categoria.");

            }
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if(CantBeDeleted(id))
                {
                    return RedirectToAction("DeleteDenied", "Produtos");
                }
               Categoria categoria = await _uow.CategoriaRepository.GetById(id);
                _uow.CategoriaRepository.Delete(categoria);
                await _uow.Commit();
                TempData["MensagemSucesso"] = "Categoria excluida com sucesso.";

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao excluir a categoria.");
            }

            return RedirectToAction("Index","Categorias");
        }
        public bool CantBeDeleted(int id)
        {
            var produtoIsAlugado = _uow.AluguelRepository.GetAlugueisByCliente();

            foreach (var produtoAlugado in produtoIsAlugado)
            {
                foreach (var item in produtoAlugado.AluguelProdutos)
                {
                    if (item.Produto.CategoriaId == id)
                    {
                        TempData["ErrorAoExcluir"] = "Não é possivel executar a exclusão pois o produto ou categoria está vinculado a um aluguel.";
                        return true;
                    }

                }

            }
            return false;
        }
    }
}
