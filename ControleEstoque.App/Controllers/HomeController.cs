using ControleEstoque.App.Models;
using ControleEstoque.App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleEstoque.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Controle de Estoque App.";
            ViewData["AboutApp"] = "Sistema Web de gestão de produtos.";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Controle de Estoque App.";
            ViewData["Email"] = "jvitorpereira10@gmail.com";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}