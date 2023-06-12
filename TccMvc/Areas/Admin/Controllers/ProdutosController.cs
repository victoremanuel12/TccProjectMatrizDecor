using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;

namespace TccMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProdutosController : Controller
    {
        private readonly IUnitOfWork _uow;

        public ProdutosController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var produtos = await _uow.ProdutoRepository.GetAll();
            return View(produtos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _uow.ProdutoRepository.GetById(id);
            if (produto == null)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao carregar a categoria.");

            }

            return View(produto);
        }

        public async Task<IActionResult> Create()
        {
            var categorias = await _uow.CategoriaRepository.GetAll();
            var categoriasSelectList = categorias.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            }).ToList();
            ViewBag.Categorias = categoriasSelectList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto, IFormFile imagemFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (imagemFile != null && imagemFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await imagemFile.CopyToAsync(memoryStream);
                            byte[] imagemBytes = memoryStream.ToArray();

                            string imagemBase64 = Convert.ToBase64String(imagemBytes);
                            produto.ImagemUrl = imagemBase64;
                        }
                    }
                    _uow.ProdutoRepository.Add(produto);
                    await _uow.Commit();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao criar o produto.");
                }


            }

            return View(produto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _uow.ProdutoRepository.GetById(id);
            if (produto == null)
            {
                TempData["Error"] = " Produto não encontrado";
            }
            var categorias = await _uow.CategoriaRepository.GetAll();
            var categoriasSelectList = categorias.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            }).ToList();
            ViewBag.Categorias = categoriasSelectList;

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Produto produto, IFormFile imagemFile)
        {
            try
            {
                var produtoRetornado = await _uow.ProdutoRepository.GetById(produto.Id);
                if (produtoRetornado == null)
                {
                    return NotFound();
                }

                if (imagemFile != null && imagemFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imagemFile.CopyToAsync(memoryStream);
                        byte[] imagemBytes = memoryStream.ToArray();
                        string imagemBase64 = Convert.ToBase64String(imagemBytes);
                        produtoRetornado.ImagemUrl = imagemBase64;
                    }

                }

                produtoRetornado.Nome = produto.Nome;
                produtoRetornado.Descricao = produto.Descricao;
                produtoRetornado.DescricaoDetalhada = produto.DescricaoDetalhada;
                produtoRetornado.Preco = produto.Preco;
                produtoRetornado.IsDisponivel = produto.IsDisponivel;
                produtoRetornado.CategoriaId = produto.CategoriaId;
                produtoRetornado.Quantidade = produtoRetornado.Quantidade += produto.Quantidade;

                _uow.ProdutoRepository.Update(produtoRetornado);
                await _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao editar o produto.");
            }

            return RedirectToAction("Index", "Produtos");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _uow.ProdutoRepository.GetById(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (CantBeDeleted(id))
            {
                return RedirectToAction("DeleteDenied", "Produtos");

            }
            var produto = await _uow.ProdutoRepository.GetById(id);
            if (produto != null)
            {
                _uow.ProdutoRepository.Delete(produto);
            }
            await _uow.Commit();

            return RedirectToAction(nameof(Index));
        }
        public bool CantBeDeleted(int id)
        {
            var produtoIsAlugado = _uow.AluguelRepository.GetAlugueisByCliente();

            foreach (var produtoAlugado in produtoIsAlugado)
            {
                foreach (var item in produtoAlugado.AluguelProdutos)
                {
                    if (item.Produto.Id == id)
                    {
                        TempData["ErrorAoExcluir"] = "Não é possivel executar a exclusão pois o produto ou categoria está vinculado a um aluguel.";
                        return true;
                    }

                }

            }
            return false;
        }
        public IActionResult DeleteDenied()
        {

            return View();
        }
    }
}


