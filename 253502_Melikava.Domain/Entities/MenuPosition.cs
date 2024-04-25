

namespace _253502_Melikava.Domain.Entities
{
    public class MenuPosition:Entity
    {
        public MenuPosition() { }
        public MenuPosition(string type,string name, double price)
        {
            Type = type;
            Name = name;
            Price = price;
        }
        private List<Order> _orders=new();
        public string? Type { get; set; }
        public string? Name { get; set; }
        public double Price { get; private set; }
        public IReadOnlyList<Order> Orders { get => _orders.AsReadOnly(); }

    }
}
