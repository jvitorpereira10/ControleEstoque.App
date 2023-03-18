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

        public async Task<IActionResult> Stock(string barCode, string description, string prodActive)
        {
            ViewData["barCode"] = barCode;
            ViewData["description"] = description;
            ViewData["prodActive"] = prodActive;

            var obj = await _productService.FindByFiltersAsync(barCode, description, prodActive);

            obj = obj.OrderBy(o => o.Stock).ToList();
            return View(obj);
        }

        public async Task<IActionResult> EditStock(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = "Id not provided." });
            }
            var obj = await _productService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = "Id not found." });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStock(int? id, string barCode, string description, int tpLancto, int stock)
        {
            Product product = await _productService.FindByIdAsync(id.Value);
            if (product == null)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = "Id not found." });
            }

            if (tpLancto == 1)
            {
                product.StockIn(product, stock);
            }
            else
            {
                product.StockOut(product, stock);
            }
            try
            {
                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Stock));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = e.Message }); ;
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = e.Message });
            }
        }

        public async Task<IActionResult> Price(string barCode, string description, string prodActive)
        {
            ViewData["barCode"] = barCode;
            ViewData["description"] = description;
            ViewData["prodActive"] = prodActive;

            var obj = await _productService.FindByFiltersAsync(barCode, description, prodActive);
            return View(obj);
        }

        public async Task<IActionResult> EditPrice(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = "Id not provided." });
            }
            var obj = await _productService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = "Id not found." });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPrice(int? id, int listPrice)
        {
            Product product = await _productService.FindByIdAsync(id.Value);
            if (product == null)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = "Id not found." });
            }

            product.UpdatePrice(product, listPrice);
           
            try
            {
                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Price));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = e.Message }); ;
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Message = e.Message });
            }
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
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
