namespace ControleEstoque.App.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }
        public string AddressCity { get; set; }

        public Seller()
        {
        }

        public Seller(int id, string name, string lastName, string phone, string email, string address, int addressNumber, string addressCity)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Address = address;
            AddressNumber = addressNumber;
            AddressCity = addressCity;
        }
    }
}
