using ControleEstoque.App.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.App.Models
{
    public class OrderItem
    {
        [Required]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {
        }
        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }
        public double SubTotal()
        {
            return Quantity * Price;
        }
    }
}
