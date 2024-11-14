using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto05_Navas.Models;

namespace Proyecto05_Navas.Controllers
{
    [Route("api/Productos")]// Aqui se coloca el nombre de las pesta;a para el postman
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private List<Producto> productos = new List<Producto>();

        public ProductosController()
        {
            productos.Add(new Producto(1, "Laptop HP", 785.99, 5));
            productos.Add(new Producto(2, "Impresora Epson L310", 315, 10));
            productos.Add(new Producto(3, "Pantalla LG 22 pulgadas", 195, 3));
        }

        [HttpGet] //este esa una referencia para saber que tipo operacion se va a hacer
        [Route("Listar")] //Para ponerle en la url y que se haga mas corto
        public List<Producto> ListarProductos()
        {
            return productos;
        }

        [HttpGet] //este esa una referencia para saber que tipo operacion se va a hacer
        [Route("Buscar")] //Para ponerle en la url y que se haga mas corto
        public Producto Buscar(int id)
        {
            try
            {
                return productos.Where(p => p.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return productos[0];
            }
        }

        [HttpGet] //este esa una referencia para saber que tipo operacion se va a hacer
        [Route("Buscar1")] //Para ponerle en la url y que se haga mas corto

        public dynamic Buscar1(int id) //dynamic me deja crear productos para ver el new por ejemplo del return que es un objeto que no existe mas para un programador que necesita saber si retorna algo 
        {
            Producto p = productos.Where(p => p.Id == id).FirstOrDefault();
            if (p == null)
            {
                return new
                {
                    respuesta = false,
                    mensaje = "Producto no encontrado"
                };
            }

            return p;

        }

        [HttpPost] //este esa una referencia para saber que tipo operacion se va a hacer
        [Route("InsertarNuevoProducto")] //Para ponerle en la url y que se haga mas corto
        public dynamic AgregarProducto(Producto nuevo)
        {
            productos.Add(nuevo);
            return new
            {
                respuesta = true,
                mensaje = "Producto creado exitosamente",
                resultado = nuevo
            };
        }
        [HttpPut("{id}")] //Este es el Update 
        public IActionResult UpdateProducto(int id, Producto producto)
        {
            var existingProduct = productos.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = producto.Name;
            existingProduct.Precio = producto.Precio;
            existingProduct.Stock = producto.Stock;

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")] //Este es el delete
        public IActionResult DeleteProducto(int id)
        {
            var productToRemove = productos.FirstOrDefault(p => p.Id == id);

            if (productToRemove == null)
            {
                return NotFound();
            }

            productos.Remove(productToRemove);

            return NoContent();
        }

    }

}
