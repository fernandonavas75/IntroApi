namespace Proyecto05_Navas.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Precio { get; set; }
        public double Stock { get; set; }
        public Producto(int id, string name, double price, double stock)
        {
            Id = id;
            Name = name;
            Precio = price;
            Stock = stock;

        }
        public Producto() { 
            Id = 0;
            Name = string.Empty;
            Precio = 0;
            Stock = 0;
        }
    }
}
