using Microsoft.AspNetCore.Mvc;
using TccMvc.Utils;

namespace TccMvc.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [AutorizacaoFiltro]
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}