﻿using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.B.P.Models;
using ProyectoDesarrollo.B.P.Services;

namespace ProyectoDesarrollo.B.P.Controllers
{
    public class TemporalVentaController : Controller
    {
        private readonly iTemporalVenta _temporalVenta;

        public TemporalVentaController(iTemporalVenta temporalVenta)
        {
            _temporalVenta = temporalVenta;
        }

        public IActionResult Index(string txtcodigo, string txtdescripcion, string txtprecio, string txtcantidad)
        {
            TemporalVenta obj = new TemporalVenta();
            int  productoExistente = _temporalVenta.ObtenerProductoPorCodigo(txtcodigo);

            if (productoExistente != -1)
            {

                _temporalVenta.AumentarCantidadProducto(txtcodigo, int.Parse(txtcantidad));
            }
            else
            {  
               
                obj.codigo = txtcodigo;
                obj.nombre = txtdescripcion;
                obj.precio = double.Parse(txtprecio);
                obj.cantidad = int.Parse(txtcantidad);

                _temporalVenta.agregar(obj);
           }

            return RedirectToAction("Catalogo", "Producto");
        }

        public IActionResult VerCarrito()
        {
            return View(_temporalVenta.ListarTemporalVenta());
        }
        [Route ("TemporalVenta/Eliminar/{codigo}")]
        public IActionResult Eliminar(string codigo)
        {
            _temporalVenta.remove(codigo);
            return RedirectToAction("Producto");
        }
    }
}
