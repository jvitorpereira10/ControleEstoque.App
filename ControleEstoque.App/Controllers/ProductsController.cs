using ControleEstoque.App.Models;
using ControleEstoque.App.Models.ViewModels;
using ControleEstoque.App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace ControleEstoque.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductService _productService;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Create()
        {            
            return View();
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }

        public async Task<IActionResult> Stock()
        {
            return View();
        }
        public async Task<IActionResult> Price()
        {
            return View();
        }

        public async Task<IActionResult> Search(string barCode, string description)
        {
            ViewData["barCode"] = barCode;
            ViewData["description"] = description;            

            Product product = null;
            if (barCode != null)
            {
                product = await _productService.FindByBarCodeAsync(barCode);
                return View(product);
            }

            product = await _productService.FindByDescriptionAsync(description);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await _productService.InsertAsync(product);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
