using SistemaDeLeilao.Filters;
using SistemaDeLeilao.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SistemaDeLeilao.Controllers
{
    [PaginaParaEmbarcadoresLogado]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
