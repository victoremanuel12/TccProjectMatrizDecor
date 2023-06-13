using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TccMvc.Repository.Interfaces;
using TccMvc.ViewModel;

namespace TccMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HistoricoAluguelController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public HistoricoAluguelController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            try
            {
                var alugueis = _uow.AluguelRepository.GetAlugueisByCliente();
                return View(_mapper.Map<List<HistoricoAlugueisViewModel>>(alugueis));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao carregar o histórico de alugueis.");

                return BadRequest(ex);
            }
        }
        public ActionResult Details(int PedidoId)
        {
            return View();
        }

    }
}
