using Microsoft.AspNetCore.Mvc;
using TccMvc.Repository.Interfaces;

namespace TccMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uow;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public  IActionResult Index()
        {
            return View();
        }
    }
}