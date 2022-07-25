using SistemaDeLeilao.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeLeilao.Controllers
{
    [PaginaParaEmbarcadoresLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
