using Microsoft.AspNetCore.Mvc;
using TccMvc.Cripitografia;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;
using TccMvc.Services;
using TccMvc.ViewModel;

namespace TccMvc.Controllers
{
    public class ContaUsuarioController : Controller
    {
        private readonly IUnitOfWork _uow;


        public ContaUsuarioController(IUnitOfWork UnitOfWork)
        {
            _uow = UnitOfWork;
        }


        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var senhaCripitrografada = Hash.MD5(cliente.Senha);
                var usuarioCadastrado = await _uow.ClienteRepository.Get(c => c.Email == cliente.Email && c.Senha == senhaCripitrografada);

                if (usuarioCadastrado != null)
                {
                    TempData["Success"] = "Login efetuado com sucesso!";
                    ClienteInSession.SetClienteInSession(HttpContext, usuarioCadastrado);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Não foi possivel efetuar o login";
                }
            }
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                string senhaCripritografada = Hash.MD5(cliente.Senha);
                var novoCliente = new Cliente
                {
                    Email = cliente.Email,
                    Senha = senhaCripritografada
                };
                _uow.ClienteRepository.Add(novoCliente);
                await _uow.Commit();
                Cliente clienteCadastrado = await _uow.ClienteRepository.Get(c => c.Email == cliente.Email);
                ClienteInSession.SetClienteInSession(HttpContext, clienteCadastrado);
                TempData["Success"] = "Cadastro efetuado com sucesso.";
                return RedirectToAction("Index", "Home");
            }
            return View(cliente);
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("userId") != "")
            {

                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
