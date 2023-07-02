using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.B.P.Services;

namespace ProyectoDesarrollo.B.P.Controllers
{
    public class ProductoController : Controller
    {
        private readonly iProducto _producto;
        public ProductoController(iProducto producto)
        {
            _producto = producto;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("Producto/Comprar/{Codigo}")]
        public IActionResult Comprar(string codigo)
        {
            return View(_producto.GetaProducto(codigo));
        }
        public IActionResult Catalogo()
        {
            return View(_producto.MostrarTodosProductos());
        }
    }
   


}
