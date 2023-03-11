using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.App.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string SellerCode { get; set; }
        public int BarCode { get; set; }
        private int Stock { get; set; }

        [DataType(DataType.Currency)]
        private double ListPrice { get; set; }
        public double PromotionalPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PromoStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PromoEnd { get; set; }

        public Product()
        {
        }

        public Product(int id, string description, string sellerCode, int barCode, int stock, double listPrice, double promotionalPrice, DateTime promoStart, DateTime promoEnd)
        {
            Id = id;
            Description = description;
            SellerCode = sellerCode;
            BarCode = barCode;
            Stock = stock;
            ListPrice = listPrice;
            PromotionalPrice = promotionalPrice;
            PromoStart = promoStart;
            PromoEnd = promoEnd;
        }

        public int StockAvailable()
        {
            return Stock;
        }

        public void StockIn(int stock)
        {
            Stock += stock;
        }

        public void StockOut(int stock)
        {
            Stock -= stock;
        }

        public void ResetStock()
        {
            Stock = 0;
        }

        public void UpdatePrice(double price)
        {
            ListPrice = price;
        }
    }
}