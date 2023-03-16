using ControleEstoque.App.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.App.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public OrderStatus Status { get; set; }
        public Seller Seller { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItem { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(int id, DateTime date, double amount, OrderStatus status, Seller seller, Client client)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
            Client = client;
        }
        public void AddItem(OrderItem item)
        {
            OrderItem.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            OrderItem.Remove(item);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrderItem item in OrderItem)
            {
                sum += item.SubTotal();
            }

            return sum;
        }
    }
}
