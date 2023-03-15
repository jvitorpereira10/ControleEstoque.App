using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.App.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        public bool ProdAtivo { get; set; }

        [Required]
        [Display(Name = "Descrição:")]
        public string Description { get; set; }

        [Display(Name = "Código do Produto:")]
        public string ProductCode { get; set; }

        [Display(Name = "Código de Barras:")]
        public string BarCode { get; set; }

        [Display(Name = "Estoque:")]
        public int Stock { get; set; }

        [Display(Name = "Preço:")]
        public double ListPrice { get; set; }

        [Display(Name = "Preço Promocional:")]
        public double PromotionalPrice { get; set; }

        [Display(Name = "Início Promoção:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PromoStart { get; set; }

        [Display(Name = "Término Promoção:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PromoEnd { get; set; }

        public Product()
        {
        }

        public Product(int id, string description, string productCode, string barCode, int stock, double listPrice, double promotionalPrice, DateTime promoStart, DateTime promoEnd)
        {
            Id = id;
            Description = description;
            ProductCode = productCode;
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