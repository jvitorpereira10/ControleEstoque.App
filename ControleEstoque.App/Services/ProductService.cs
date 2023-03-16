using ControleEstoque.App.Data;
using ControleEstoque.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ControleEstoque.App.Services
{
    public class ProductService
    {
        private readonly ControleEstoqueContext _context;

        public ProductService(ControleEstoqueContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.OrderBy(p => p.Stock).ToListAsync();
        }

        public async Task InsertAsync(Product obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            // Using eager loading "Include" to return all objets relateds with main object.
            // In this case, will return Department of respective Product.
            return await _context.Product.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<List<Product>> FindByFiltersAsync(string barCode, string description, string active)
        {
            List<Product> obj = new();            

            if (!string.IsNullOrEmpty(barCode) && !string.IsNullOrEmpty(description))
            {
                obj = await _context.Product
                        .Where(obj => obj.BarCode.Contains(barCode))
                        .Where(obj => obj.Description.Contains(description))
                        .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(barCode) && string.IsNullOrEmpty(description))
            {
                obj = await _context.Product
                       .Where(obj => obj.BarCode.Contains(barCode))
                       .ToListAsync();
            }else if (string.IsNullOrEmpty(barCode) && !string.IsNullOrEmpty(description))
            {
                obj = await _context.Product
                       .Where(obj => obj.Description.Contains(description))
                       .ToListAsync();
            }
            else
            {
                obj = await _context.Product
                       .ToListAsync();
            }

            if (!string.IsNullOrEmpty(active) && active != "2")
            {
                bool prodActive = active.Equals("1") ? true : false;
                return obj.Where(a => a.ProdActive.Equals(prodActive)).ToList();
            }

            return obj;
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Product.FindAsync(id);
                _context.Product.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                string messageError = e.InnerException.Message;
                if (!string.IsNullOrEmpty(messageError) && (bool)messageError?.ToUpper()?.Contains("FK_SALESRECORD_Product_ProductID"))
                {
                    throw new IntegrityException($"Can't delete Product because he/she has sales.");
                }
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Product product)
        {
            if (!await _context.Product.AnyAsync(obj => obj.Id == product.Id))
            {
                throw new NotFoundException("Id not found.");
            }
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
