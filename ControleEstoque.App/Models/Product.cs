using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ControleEstoque.App.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Ativo")]
        public bool ProdActive { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Código do Produto")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Código de Barras")]
        public string BarCode { get; set; }

        [Display(Name = "Estoque")]
        public int Stock { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public double ListPrice { get; set; }

        [Display(Name = "Preço Promocional")]
        [DataType(DataType.Currency)]
        public double PromotionalPrice { get; set; }

        [Display(Name = "Início Promoção")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PromoStart { get; set; }

        [Display(Name = "Término Promoção")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PromoEnd { get; set; }

        public Product()
        {
        }

        public Product(int id, bool prodActive, string description, string productCode, string barCode, int stock, double listPrice, double promotionalPrice, DateTime promoStart, DateTime promoEnd)
        {
            Id = id;
            ProdActive = prodActive;
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

        public void StockIn(Product product, int stock)
        {
            product.Stock += stock;
        }

        public void StockOut(Product product, int stock)
        {
            product.Stock -= stock;
        }

        public void ResetStock()
        {
            Stock = 0;
        }

        public void UpdatePrice(Product product, double price)
        {
            product.ListPrice = price;
        }
    }
}