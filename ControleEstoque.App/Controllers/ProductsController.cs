using ControleEstoque.App.Models;
using ControleEstoque.App.Models.ViewModels;
using ControleEstoque.App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ControleEstoque.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string barCode, string description)
        {
            var obj = await _productService.FindAllAsync();
            return View(obj);
        }

        public async Task<IActionResult> Stock()
        {
            return View();
        }
        public async Task<IActionResult> Price()
        {
            return View();
        }

        public async Task<IActionResult> Details(string barCode, string description, string prodActive)
        {
            ViewData["barCode"] = barCode;
            ViewData["description"] = description;
            ViewData["prodActive"] = prodActive;

            var obj = await _productService.FindByFiltersAsync(barCode, description, prodActive);

            return View(obj);
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
            return RedirectToAction(nameof(Create));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
